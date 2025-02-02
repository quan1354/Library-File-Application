using ModuleControl.EventHandler;
using MyMovieApplication.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static ModuleControl.Services.MyService;
using O2S.Components.PDFView4NET;
using O2S.Components.PDFView4NET.WPF;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Windows.Controls;

namespace LibraryApplication.ModuleControl.ViewModels
{
    public class CenterView_2_ViewModel : BindableBase, INavigationAware
    {
        #region Fields
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
        private string _DocumentTitle;
        private VideoItem _SelectedDocument;
        private string _DescriptionContent;
        private readonly IEventAggregator _eventAggregator;
        private ICommand _OpenPDF { get; set; }
        private ICommand _DownloadBtnClick { get; set; }
        private bool downloadIsClick;
        private ICommand _TermCheckBoxClick { get; set; }
        private Visibility _PDFVisibility = Visibility.Collapsed;
        private Visibility _ImageVisibility = Visibility.Collapsed;
        private Visibility _PPTXVisibility = Visibility.Collapsed;
        private string _ImageUrl;
        private PDFDocument _pdfDocument;
        public event EventHandler SlidesLoaded;
        public event EventHandler EnableNavigationButtons;
        public PowerPoint.Presentation presentation;
        #endregion
        #region GETTER SETTER
        public PDFDocument PdfDocument
        {
            get {return _pdfDocument; }
            set
            {
                try
                {
                    SetProperty(ref _pdfDocument, value);
                }
                catch (Exception ex) {
                    Console.Write(ex);
                }
            }
        }
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { SetProperty(ref _ImageUrl, value); }
        }
        public bool DownloadIsClick
        {
            get { return downloadIsClick; }
            set { SetProperty(ref downloadIsClick, value); }
        }
        public string DocumentTitle
        {
            get {return _DocumentTitle; }
            set { SetProperty(ref _DocumentTitle, value); }
        }
        public string DescriptionContent
        {
            get { return _DescriptionContent; }
            set { SetProperty(ref _DescriptionContent, value); }
        }
        public VideoItem SelectedDocument
        {
            get { return _SelectedDocument; }
            set { SetProperty(ref _SelectedDocument, value); }
        }
        public Visibility PDFVisibility
        {
            get { return _PDFVisibility; }
            set { SetProperty(ref _PDFVisibility, value); }
        }
        public Visibility ImageVisibility
        {
            get { return _ImageVisibility; }
            set { SetProperty(ref _ImageVisibility, value); }
        }
        public Visibility PPTXVisibility
        {
            get {return _PPTXVisibility; }
            set {SetProperty(ref _PPTXVisibility, value); }
        }

        #endregion

        public ICommand DownloadBtnClick
        {
            get
            {
                return _DownloadBtnClick ?? (_DownloadBtnClick = new RelayCommand<object>(x =>
                {
                    // Get the video path from your ViewModel (CenterViewModel)
                    string videoPath = SelectedDocument.VideoPath;

                    // Find the available pendrive
                    string pendriveLetter = GetAvailablePendriveLetter();
                    //string pendriveLetter = "D";

                    if (!string.IsNullOrEmpty(pendriveLetter))
                    {
                        // Set the destination folder path on the pendrive
                        string destinationFolderPath = $"{pendriveLetter}:\\";

                        // Get the file name from the video path
                        string fileName = Path.GetFileName(videoPath);

                        // Build the destination file path
                        string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                        // Copy the video file to the destination folder
                        File.Copy(videoPath, destinationFilePath, true);

                        // Optionally, show a message to the user indicating that the download is complete
                        MessageBox.Show("Download complete!");
                    }
                    else
                    {
                        // Handle the case when no pendrive is available
                        MessageBox.Show("No pendrive detected. Please insert a pendrive to proceed download.\n 电脑未能侦测到数据盘, 请插入数据盘");
                    }
                }));
            }
        }
        public ICommand TermCheckBoxClick {
            get
            {
                return _TermCheckBoxClick ?? (_TermCheckBoxClick = new RelayCommand<object>(x =>
                {
                    if (DownloadIsClick == true)
                        DownloadIsClick = false;
                    else
                        DownloadIsClick = true;
                }));
            }
        }

        public ICommand OpenPDF
        {
            get {
                return _OpenPDF ?? (_OpenPDF = new RelayCommand<object>(x =>
                {
                    Process.Start(SelectedDocument.VideoPath);
                }));
            }
        }

        public CenterView_2_ViewModel(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;
            DownloadIsClick = false;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<MessageSendVisibility>().Publish(Visibility.Collapsed);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<MessageSendVisibility>().Publish(Visibility.Visible);
            if (navigationContext.Parameters.ContainsKey("SelectedDocument"))
            {
                SelectedDocument = navigationContext.Parameters.GetValue<VideoItem>("SelectedDocument");
                DocumentTitle = Path.GetFileNameWithoutExtension(SelectedDocument.VideoName);

                // Images
                if (imageExtensions.Contains(SelectedDocument.FileType)) {
                    ImageVisibility =  Visibility.Visible;
                    ImageUrl = SelectedDocument.VideoPath;
                }
                else {
                    ImageVisibility = Visibility.Collapsed;
                }

                // PDF
                if (SelectedDocument.FileType == ".pdf")
                {
                    PdfDocument = new PDFDocument();
                    PdfDocument.Load(SelectedDocument.VideoPath);
 
                    PDFVisibility = Visibility.Visible;
                }
                else {
                    PDFVisibility = Visibility.Collapsed;
                }

                if (SelectedDocument.FileType == ".pptx")
                {
                    var powerPointApp = new PowerPoint.Application();
                    try
                    {
                        // Open the PowerPoint file using the SelectedDocument's path
                        presentation = powerPointApp.Presentations.Open(SelectedDocument.VideoPath, ReadOnly: Microsoft.Office.Core.MsoTriState.msoFalse, Untitled: Microsoft.Office.Core.MsoTriState.msoFalse);
                        SlidesLoaded?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (powerPointApp != null)
                            powerPointApp.Quit();
                    }
                    EnableNavigationButtons?.Invoke(this, EventArgs.Empty);
                    // Enable navigation buttons after loading slides
                    PPTXVisibility = Visibility.Visible;
                }
                else {
                    PPTXVisibility = Visibility.Collapsed;
                }

                // Description
                bool isFileExist = false;
                if (VideoDescriptions != null)
                {
                    // Filter out objects with the same video name and select the first occurrence
                    var distinctVideoDescriptions = VideoDescriptions
                        .GroupBy(vd => vd.VideoName)
                        .Select(group => group.First());
                    foreach (var description in distinctVideoDescriptions)
                    {
                        if (string.Equals(SelectedDocument.VideoName, description.VideoName, StringComparison.OrdinalIgnoreCase)) {
                            DescriptionContent = description.Description;
                            isFileExist = true;
                        }     
                    }
                }
                if (isFileExist == false || DescriptionContent == "") DescriptionContent = "No Description ...";
            }
        }

        private string GetAvailablePendriveLetter()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    return drive.RootDirectory.FullName.Substring(0, 1);
                }
            }

            return string.Empty;
        }

    }
}
