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
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using System.Xml.Serialization;
using static ModuleControl.Services.MyService;
//using Microsoft.WindowsAPICodePack.Shell;

namespace ModuleControl.ViewModels
{
    class HomeViewModel : BindableBase
    {
        #region FIELDS
        //private ObservableCollection<Video> _videoList;
        //private ObservableCollection<Folder> _folderList;
        string[] videoExtensions = { ".mp3", ".mpg", ".mpeg", ".mp4", ".ts", ".mkv" };
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
        string[] validFileExtensions = { ".mp3", ".mpg", ".mpeg", ".mp4", ".ts", ".mkv", ".pdf", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".pptx" };
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        private IEventAggregator _eventAggregator;
        private readonly MyService myservice;
        private readonly DatabaseService dbService;
        private int _counter;
        public IRegionManager RegionManager { get; }
        public DelegateCommand<VideoItem> SendMessageCommand { get; set; }
        public DelegateCommand<string> ChangeFolder { get; set; }
        public DelegateCommand<Video> DeleteItem_Command { get; set; }
        public DelegateCommand<Video> UpdateItem_Command { get; set; }
        public DelegateCommand Refresh_Command { get; private set; }
        public DelegateCommand InsertItem_Command { get; set; }
        private Visibility _DescriptBtnVisibility = Visibility.Collapsed;
        private ICommand _Counter_Command;
        public ICommand UpCommand { get; }
        public ICommand _SearchCommand;
        public ICommand _DescriptionCommand;
        private string _FilePathAnchor;
        public string _SearchText = string.Empty;

        //private bool _canExecute = true;

        private ObservableCollection<FolderItem> _folders;
        private ObservableCollection<VideoItem> _videos;
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
        public ObservableCollection<VideoItem> Videos {
            get { return _videos; }
            set
            {
                SetProperty(ref _videos, value);
            
            }
        }
        //public ObservableCollection<Video> VideoList
        //{
        //    get { return _videoList; }
        //    set
        //    {
        //        SetProperty(ref _videoList, value);
        //    }
        //}
        //public ObservableCollection<Folder> FolderList
        //{
        //    get { return _folderList; }
        //    set
        //    {
        //        SetProperty (ref _folderList, value);
        //    }
        //}
        //public bool CanExecute
        //{
        //    get { return _canExecute; }
        //    set { SetProperty(ref _canExecute, value); }
        //}
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
                if (SelectedFolder != null) {
                    if (SelectedFolder.Videos != null)
                    {
                        Videos = SelectedFolder.Videos;
                    }
                    else {
                        string [] videoFiles = Directory.GetFiles(SelectedFolder.FolderPath).Where(file => {
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
            //DeleteItem_Command = new DelegateCommand<Video>(DeleteItem);
            //InsertItem_Command = new DelegateCommand(InserItem);
            //UpdateItem_Command = new DelegateCommand<Video>(UpdateItem);


            _eventAggregator = eventAggregator;
            eventAggregator.GetEvent<MessageSendAdminVisibility>().Subscribe(descriptionBtnVisible => {
                DescriptBtnVisibility = descriptionBtnVisible;
            });

            RegionManager = regionManager;
            this.myservice = myservice;
            this.dbService = dbService;

            //Refresh_Command = new DelegateCommand(refreshVideoList).ObservesCanExecute(() => CanExecute);
            //applicationCommands.refreshCommand.RegisterCommand(Refresh_Command);

            //dbService.insertData();

            //VideoList = dbService.selectAllVideoData();
            //FolderList = dbService.selectAllFolderData();
            //SaveAllDataToXml();

            //ReadCounterValueFromFile();
            Folders = new ObservableCollection<FolderItem>();
            LoadFolders(@"C:\LibraryMaterial");

        }
        #endregion

        public ICommand Counter_Command
        {
            get
            {
                return _Counter_Command ?? (_Counter_Command = new RelayCommand<object>(x =>
                {
                    Counter++;
                    SaveCounterValuesToFile(Counter);
                }));
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return _SearchCommand ?? (_SearchCommand = new RelayCommand<object>(x =>
                {
                    //string keyword = Regex.Escape(SearchText?.Trim());
                    string keyword = new string(SearchText?.Trim()
                            .Where(c => !Path.GetInvalidFileNameChars().Contains(c))
                            .ToArray());
                    //keyword = Regex.Replace(keyword, @"[^a-zA-Z0-9]+", "");

                    // Perform the search in the specified path (C:\Users\jqchuah\Videos) using the keyword
                    string path = @"C:\LibraryMaterial";
                    DirectoryInfo directory = new DirectoryInfo(path);

                    // Search for folders matching the keyword
                    var matchingFolders = directory.GetDirectories("*" + keyword + "*", SearchOption.AllDirectories)
                        .Where(f => f.Name.Contains(keyword));

                    // Search for videos matching the keyword or other criteria
                    var matchingVideos = new List<FileInfo>();

                    //foreach (var file in directory.GetFiles("*", SearchOption.AllDirectories))
                    //{
                    //    FileInfo fileInfo = new FileInfo(file.FullName);

                    //    if (file.Name.Contains(keyword) ||
                    //        fileInfo.LastWriteTime.ToString("M/d/yyyy h:mm:ss tt").Contains(keyword) ||
                    //        fileInfo.Extension.Contains(keyword) ||
                    //        (IsVideoFile(file.FullName) && GetVideoLength(file.FullName).ToString().Contains(keyword)))
                    //    {
                    //        matchingVideos.Add(fileInfo);
                    //    }
                    //}

                    foreach (var file in directory.GetFiles("*", SearchOption.AllDirectories))
                    {
                        FileInfo fileInfo = new FileInfo(file.FullName);

                        if (file.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            fileInfo.LastWriteTime.ToString("Mdyyyy hmmss tt")
                                .IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            fileInfo.Extension.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            (IsVideoFile(file.FullName) && GetVideoLength(file.FullName).ToString()
                                .IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            matchingVideos.Add(fileInfo);
                        }
                    }

                    // Update the Folders and Videos collections with the search results
                    Folders = new ObservableCollection<FolderItem>(matchingFolders.Select(f => new FolderItem(f.Name, f.FullName)));
                    //SelectedFolder = Folders.FirstOrDefault();
                    Videos = new ObservableCollection<VideoItem>(matchingVideos.Select(v =>
                    {
                        double sizeInBytes = v.Length;
                        int i = 0;
                        while (sizeInBytes >= 1024 && i < sizes.Length - 1)
                        {
                            sizeInBytes /= 1024;
                            i++;
                        }
                        return new VideoItem
                        {
                            VideoName = Path.GetFileNameWithoutExtension(v.Name),
                            VideoPath = v.FullName,
                            LastModified = v.LastWriteTime,
                            FileType = v.Extension,
                            FileSize = Math.Round(sizeInBytes, 2).ToString("N2") + " " + sizes[i],
                            VideoLength = GetVideoLength(v.FullName),
                            Description = "This is video"
                        };
                    }));

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
        //private void LoadFolders(string folderPath)
        //{
        //    Folders.Clear();

        //    string[] folderDirectories = Directory.GetDirectories(folderPath);

        //    foreach (string folderDirectory in folderDirectories)
        //    {
        //        string folderName = new DirectoryInfo(folderDirectory).Name;
        //        FolderItem folderItem = new FolderItem { FolderName = folderName, FolderPath = folderDirectory };
        //        Folders.Add(folderItem);
        //    }
        //}

        private void LoadFolders(string folderPath)
        {
            Folders.Clear();
            string[] folderDirectories = Directory.GetDirectories(folderPath);

            foreach (string folderDirectory in folderDirectories)
            {
                string subFolderName = new DirectoryInfo(folderDirectory).Name;
                string subFolderPath = new DirectoryInfo(folderDirectory).FullName;
                FolderItem folderItem = new FolderItem { FolderName = subFolderName, FolderPath = subFolderPath };

                string[] videoFiles = Directory.GetFiles(folderDirectory, "*").Where(file => {
                    return IsVideoFile(file);
                }).ToArray();

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

                    folderItem.Videos.Add(new VideoItem
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
                Folders.Add(folderItem);
            }

            if (Folders.Count != 0) {
                SelectedFolder = Folders.FirstOrDefault();
                Videos = SelectedFolder.Videos;
            }
            FilePathAnchor = folderPath;
            
        }
        private TimeSpan GetVideoLength(string videoFile)
        {
            string ffprobePath = "C:\\ffmpeg-6.0-essentials_build\\bin\\ffprobe.exe"; // Update this path to the ffprobe executable
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

            if (FilePathAnchor.Equals("C:\\LibraryMaterial", StringComparison.OrdinalIgnoreCase))
            {
                LoadFolders(@"C:\LibraryMaterial");
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

        public void ReadCounterValueFromFile()
        {
            try
            {
                //string filePath = "../../../../ModuleControl/Data/Counter.xml";
                string filePath = "D:\\Counter.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(CounterData));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    CounterData counterData = (CounterData)serializer.Deserialize(fileStream);
                    Counter = counterData.Counter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading counter value: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveCounterValuesToFile(int value)
        {
            try
            {
                XDocument document = new XDocument(new XElement("Counters"));
                document.Root?.Add(new XElement("Counter", value));

                //string filePath = "../../../../ModuleControl/Data/Counter.xml";
                string filePath = "D:\\Counter.xml";
                document.Save(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving counter values: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //public void SaveAllDataToXml()
        //{
        //    // Create an instance of XmlSerializer for the Video class
        //    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Video>));

        //    // Specify the path and filename for the XML file
        //    string filePath = "../../../../ModuleControl/Data/Data.xml";

        //    // Open a file stream for writing
        //    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        // Serialize the ObservableCollection to XML and write it to the file
        //        serializer.Serialize(fileStream, VideoList);
        //    }
        //}
        public void SendMessage(VideoItem video)
        {
            //eventAggregator.GetEvent<MessageSendEvent>().Publish("Visible");
            if (video == null) return;
            var NavParameter = new NavigationParameters();

            if (videoExtensions.Contains(video.FileType)){
                NavParameter.Add("SelectedVideo", video);
                RegionManager.RequestNavigate("CenterRegion", "CenterView", NavParameter);
            } else if(video.FileType == ".pdf" || video.FileType == ".pptx" || imageExtensions.Contains(video.FileType))
            {
                NavParameter.Add("SelectedDocument", video);
                RegionManager.RequestNavigate("CenterRegion", "CenterView_2", NavParameter);
            }
            else {
                MessageBox.Show("This System not support this file", "Invalid File");
            }  
        }
        //public void InserItem()
        //{

        //    Video temp = new Video();
        //    temp.Name = "Snow White";
        //    temp.Date = DateTime.Now;
        //    temp.Description = "She is very white";
        //    temp.Path = "-";

        //    temp = dbService.insertData(temp);
        //    VideoList.Add(temp);
        //}

        //public void DeleteItem(Video deleteItem)
        //{
        //    if (deleteItem != null)
        //    {
        //        MessageBoxResult confitmDeleteDialog = MessageBox.Show("Are You Sure to Delete\n" + deleteItem.Name + "?", "Delete Video Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);

        //        switch (confitmDeleteDialog)
        //        {
        //            case MessageBoxResult.OK:
        //                dbService.deleteItem(deleteItem);
        //                var record = VideoList.FirstOrDefault(item => item.VideoID == deleteItem.VideoID);
        //                VideoList.Remove(record);
        //                break;
        //            case MessageBoxResult.Cancel:
        //                //VideoList[0].Name = "abc";
        //                // DemoList[0].Name = "abc";
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //}

        //public void UpdateItem(Video video)
        //{
        //    UpdateFormDialog updateDialog = new UpdateFormDialog("Update Form", video, dbService);
        //    updateDialog.Show();
        //}
        #endregion


    }
}
