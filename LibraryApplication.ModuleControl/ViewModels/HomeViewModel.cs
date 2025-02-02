using LibraryApplication.Core.Events;
using LibraryApplication.ModuleControl.Dialogs;
using ModuleControl.EventHandler;
using ModuleControl.Services;
using MyMovieApplication.Core.Commands;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using System.Xml.Serialization;
using static ModuleControl.Services.MyService;
using System.Collections.Concurrent;
using Newtonsoft.Json;


namespace ModuleControl.ViewModels
{
    class HomeViewModel : BindableBase
    {
        #region FIELDS
        //private ObservableCollection<Video> _videoList;
        //private ObservableCollection<Folder> _folderList;
        string[] videoExtensions = { ".mp3", ".mpg", ".mpeg", ".mp4", ".ts", ".mkv" };
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
        string[] validFileExtensions = { ".mp3", ".mpg", ".mpeg", ".mp4", ".ts", ".mkv", ".pdf", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".pptx", ".docx" };
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        private IEventAggregator _eventAggregator;
        private readonly MyService myservice;

        private int _counter;
        public IRegionManager RegionManager { get; }
        public DelegateCommand<VideoItem> SendMessageCommand { get; set; }
        public DelegateCommand<string> ChangeFolder { get; set; }
        public DelegateCommand<Video> DeleteItem_Command { get; set; }
        public DelegateCommand<Video> UpdateItem_Command { get; set; }
        public DelegateCommand Refresh_Command { get; private set; }
        public DelegateCommand InsertItem_Command { get; set; }
        private Visibility _DescriptBtnVisibility = Visibility.Collapsed;

        public ICommand UpCommand { get; }
        public ICommand _SearchCommand;
        public ICommand _DescriptionCommand;
        private string _FilePathAnchor;
        public string _SearchText = string.Empty;

        //private bool _canExecute = true;

        private ObservableCollection<FolderItem> _folders;
        private ObservableCollection<VideoItem> _videos;
        public ObservableCollection<FolderItem> cachedFolders = null;
        private FolderItem _selectedFolder;
        #endregion

        #region GETTER SETTER
        public int Counter
        {
            get { return _counter; }
            set
            {
                SetProperty(ref _counter, value);
            }
        }

        public Visibility DescriptBtnVisibility
        {
            get { return _DescriptBtnVisibility; }
            set
            {
                SetProperty(ref _DescriptBtnVisibility, value);
            }
        }
        public string FilePathAnchor
        {
            get { return _FilePathAnchor; }
            set
            {
                SetProperty(ref _FilePathAnchor, value);
            }
        }
        public ObservableCollection<VideoItem> Videos
        {
            get { return _videos; }
            set
            {
                SetProperty(ref _videos, value);

            }
        }

        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                SetProperty(ref _SearchText, value);
            }
        }
        public ObservableCollection<FolderItem> Folders
        {
            get { return _folders; }
            set { SetProperty(ref _folders, value); }
        }
        public FolderItem SelectedFolder
        {
            get { return _selectedFolder; }
            set
            {
                SetProperty(ref _selectedFolder, value);
                if (SelectedFolder != null)
                {
                    if (SelectedFolder.Videos != null)
                    {
                        Videos = SelectedFolder.Videos;
                    }
                    else
                    {
                        string[] videoFiles = Directory.GetFiles(SelectedFolder.FolderPath).Where(file => {
                            return IsVideoFile(file);
                        }).ToArray();
                        Videos.Clear();
                        foreach (string videoFile in videoFiles)
                        {
                            FileInfo fileInfo = new FileInfo(videoFile);
                            double sizeInBytes = fileInfo.Length;
                            int i = 0;
                            while (sizeInBytes >= 1024 && i < sizes.Length - 1)
                            {
                                sizeInBytes /= 1024;
                                i++;
                            }

                            Videos.Add(new VideoItem
                            {
                                VideoName = Path.GetFileNameWithoutExtension(videoFile),
                                VideoPath = videoFile,
                                LastModified = fileInfo.LastWriteTime,
                                FileType = fileInfo.Extension,
                                FileSize = Math.Round(sizeInBytes, 2).ToString("N2") + " " + sizes[i],
                                VideoLength = GetVideoLength(videoFile),
                                Description = "This is video"
                            });
                        }
                    }
                }
            }
        }
        #endregion

        #region CONSTRUCTOR
        public HomeViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, MyService myservice, DatabaseService dbService, IApplicationCommands applicationCommands)
        {
            SendMessageCommand = new DelegateCommand<VideoItem>(SendMessage);
            ChangeFolder = new DelegateCommand<string>(LoadFolders);
            UpCommand = new DelegateCommand(UpFolder);

            _eventAggregator = eventAggregator;
            eventAggregator.GetEvent<MessageSendAdminVisibility>().Subscribe(descriptionBtnVisible => {
                DescriptBtnVisibility = descriptionBtnVisible;
            });

            RegionManager = regionManager;
            this.myservice = myservice;

            Folders = new ObservableCollection<FolderItem>();
            Videos = new ObservableCollection<VideoItem>();
            LoadFolders(@"D:\LibraryMaterial");

        }
        #endregion

        public ICommand SearchCommand
        {
            get
            {
                return _SearchCommand ?? (_SearchCommand = new RelayCommand<object>(x =>
                {
                    if (string.IsNullOrWhiteSpace(SearchText))
                    {
                        MessageBox.Show("Please enter a keyword to search.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    string keyword = SearchText.Trim();

                    // Filter folders and videos using the cached data
                    var matchingFolders = cachedFolders
                        ?.Where(f => f.FolderName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                    var matchingVideos = cachedFolders
                        ?.SelectMany(f => f.Videos)
                        .Where(v => v.VideoName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    v.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    v.FileType.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                    // Update the collections with search results
                    Folders = new ObservableCollection<FolderItem>(matchingFolders ?? Enumerable.Empty<FolderItem>());
                    Videos = new ObservableCollection<VideoItem>(matchingVideos ?? Enumerable.Empty<VideoItem>());

                    if (Folders.Count == 0 && Videos.Count == 0)
                    {
                        MessageBox.Show("No matching results found.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    // Clear the search text after the search is complete
                    SearchText = string.Empty;
                }));
            }
        }



        public ICommand DescriptionCommand
        {
            get
            {
                return _DescriptionCommand ?? (_DescriptionCommand = new RelayCommand<object>(x =>
                {
                    AddDescriptionDialog descriptionDialog = new AddDescriptionDialog(Videos);
                    descriptionDialog.Show();
                }));
            }
        }

        #region FUNCTION
        private void LoadFolders(string folderPath)
        {
            // string cacheFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryMaterialCache.json");
            string cacheFilePath = "D:\\LibraryMaterial\\LibraryMaterialCache.json";

            try
            {
                // Initialize cachedFolders if null
                if (cachedFolders == null && File.Exists(cacheFilePath))
                {
                    string cacheJson = File.ReadAllText(cacheFilePath);
                    cachedFolders = JsonConvert.DeserializeObject<ObservableCollection<FolderItem>>(cacheJson);
                }

                // Filter folders in the current directory
                if (cachedFolders != null)
                {
                    if (folderPath == "D:\\LibraryMaterial")
                    {
                        Folders = new ObservableCollection<FolderItem>(
                            cachedFolders.Where(f => Path.GetDirectoryName(f.FolderPath) == folderPath));
                        SelectedFolder = Folders.FirstOrDefault();

                        if (SelectedFolder != null)
                        {
                            var currentFolder = cachedFolders.FirstOrDefault(f => f.FolderPath == SelectedFolder.FolderPath);
                            Videos = currentFolder?.Videos ?? new ObservableCollection<VideoItem>();
                        }
                        else
                        {
                            Videos = new ObservableCollection<VideoItem>();
                        }

                        FilePathAnchor = folderPath;
                    }
                    else
                    {
                        var subfolders = cachedFolders.Where(f => Path.GetDirectoryName(f.FolderPath) == folderPath).ToList();

                        if (subfolders.Count == 0)
                        {
                            // Show message box if no subfolders
                            MessageBox.Show("This folder doesn't have any subfolders.", "No Subfolders", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                        Folders = new ObservableCollection<FolderItem>(subfolders);
                        SelectedFolder = Folders.FirstOrDefault();

                        var currentFolder = cachedFolders.FirstOrDefault(f => f.FolderPath == folderPath);
                        Videos = currentFolder?.Videos ?? new ObservableCollection<VideoItem>();

                        FilePathAnchor = folderPath;
                    }

                    return;
                }

                // If cache is not available or folderPath not found, scan and cache folders
                ScanAndCacheFolders(folderPath, cacheFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading folders: {ex.Message}");
            }
        }





        private void ScanAndCacheFolders(string folderPath, string cacheFilePath)
        {
            try
            {
                Folders.Clear();
                string[] folderDirectories = Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

                foreach (string folderDirectory in folderDirectories)
                {
                    string folderName = new DirectoryInfo(folderDirectory).Name;
                    FolderItem folderItem = new FolderItem(folderName, folderDirectory);

                    // Get all valid files in the folder
                    // TODO:
                    string[] validFiles = Directory.GetFiles(folderDirectory)
                        .Where(IsValidFile)
                        .ToArray();

                    foreach (string filePath in validFiles)
                    {


                        FileInfo fileInfo = new FileInfo(filePath);
                        string fileDetails = $"File Name: {fileInfo.Name}\n" +
                         $"Full Path: {fileInfo.FullName}\n" +
                         $"Size: {fileInfo.Length} bytes\n" +
                         $"Created: {fileInfo.CreationTime}\n" +
                         $"Last Modified: {fileInfo.LastWriteTime}";

                        double sizeInBytes = fileInfo.Length;
                        int i = 0;
                        while (sizeInBytes >= 1024 && i < sizes.Length - 1)
                        {
                            sizeInBytes /= 1024;
                            i++;
                        }
  
                        string VideoName = Path.GetFileNameWithoutExtension(filePath);

                        folderItem.Videos.Add(new VideoItem
                        {
                            VideoName = Path.GetFileNameWithoutExtension(filePath),
                            VideoPath = filePath,
                            LastModified = fileInfo.LastWriteTime,
                            FileType = fileInfo.Extension,
                            FileSize = Math.Round(sizeInBytes, 2).ToString("N2") + " " + sizes[i],
                            VideoLength = GetVideoLength(filePath),
                            Description = "This is video"
                        });

                    }

                    Folders.Add(folderItem);

                }

                // Save to cache
                string cacheJson = JsonConvert.SerializeObject(Folders, Newtonsoft.Json.Formatting.Indented);


                File.WriteAllText(cacheFilePath, cacheJson);


                LoadFolders("D:\\LibraryMaterial");


                /*                if (Folders.Count > 0)
                                {
                                    SelectedFolder = Folders.FirstOrDefault();
                                    Videos = SelectedFolder?.Videos;
                                }
                                FilePathAnchor = folderPath;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scanning and caching folders: {ex.Message}");
            }
        }

        private bool IsValidFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return validFileExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private TimeSpan GetVideoLength(string videoFile)
        {
            string ffprobePath = "D:\\ffmpeg-6.0-essentials_build\\bin\\ffprobe.exe"; // Update this path to the ffprobe executable
            string arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{videoFile}\"";

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffprobePath,
                    Arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{videoFile}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            double durationSeconds;
            double.TryParse(output, out durationSeconds);
            TimeSpan videoLength = TimeSpan.FromSeconds(durationSeconds);

            // Remove milliseconds part
            videoLength = new TimeSpan(videoLength.Hours, videoLength.Minutes, videoLength.Seconds);

            return videoLength;
        }

        private void UpFolder()
        {
            string parentFolderPath = Directory.GetParent(FilePathAnchor)?.FullName;

            if (FilePathAnchor.Equals("D:\\LibraryMaterial", StringComparison.OrdinalIgnoreCase))
            {
                LoadFolders(@"D:\LibraryMaterial");
                return;
            }

            if (parentFolderPath != null)
            {
                LoadFolders(parentFolderPath);
                FilePathAnchor = parentFolderPath;
            }
        }
        private bool IsVideoFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return validFileExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public void SendMessage(VideoItem video)
        {
            //eventAggregator.GetEvent<MessageSendEvent>().Publish("Visible");
            if (video == null) return;
            var NavParameter = new NavigationParameters();

            if (videoExtensions.Contains(video.FileType))
            {
                NavParameter.Add("SelectedVideo", video);
                RegionManager.RequestNavigate("CenterRegion", "CenterView", NavParameter);
            }
            else if (video.FileType == ".pdf" || video.FileType == ".pptx" || video.FileType == ".docx" || imageExtensions.Contains(video.FileType))
            {
                NavParameter.Add("SelectedDocument", video);
                RegionManager.RequestNavigate("CenterRegion", "CenterView_2", NavParameter);
            }
            else
            {
                MessageBox.Show("This System not support this file", "Invalid File");
            }
        }
        #endregion


    }
}
