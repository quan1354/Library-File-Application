using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using Prism.Regions;
using static ModuleControl.Services.MyService;
using System.Windows.Input;
using ModuleControl.EventHandler;
using ModuleControl.Dialogs;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using System.Collections.ObjectModel;
using MyMovieApplication.Core.Events;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace ModuleControl.ViewModels
{
    public class CenterViewModel : BindableBase, INavigationAware
    {
        #region FIELDS
        // Command
        public DelegateCommand TermCheckBoxClick { get; set; }

        // Movie
        private string _movieTitle = "Rapunzel";
        private bool downloadIsClick;
        private bool _MediaButtonIsClick;
        private VideoItem _selectedVideo;
        public string descriptionContent = "No Description";
        private ICommand _TermAndConditionDialog { get; set; }
        private MediaElement _MediaPlayerElement = new MediaElement();
        private bool MediaIsPlaying { get; set; } = false;
        private double CurrentTimeSpan { get; set; }
        private double TotalTimeSpan { get; set; }
        private string _TimeElasped = "--::--";
        private string _TotalMediaTime = "--::--";
        private double MediaProgress { get; set; } = 0;
        private double _ProgressBarLength;
        private Thickness _SliderPosition;
        private Window _window;
        private ObservableCollection<VolumeControl> _VolumeControlHeights { get; set; }
        // Color for volume bar background
        SolidColorBrush VolumeBarColor = (SolidColorBrush)new BrushConverter().ConvertFromString("#0DCCFE");
        private int currentVolumePosition { get; set; } = 0;
        private double _BarLength;
        public event PropertyChangedEventHandler PropertyChange;
        private Visibility _SliderVisibility = Visibility.Collapsed;
        private Visibility _VinylVisibility = Visibility.Collapsed;
        private readonly IEventAggregator _eventAggregator;
        private ICommand _StopCommand { get; set; }
        private ICommand _PlayCommand { get; set; }
        private ICommand _RewindCommand { get; set; }
        private ICommand _ForwardCommand { get; set; }
        private string _MediaPathUrlToStored;
        #endregion

        #region GETTER SETTER
        public MediaElement MediaPlayerElement
        {
            get { return _MediaPlayerElement; }
            set
            {
                if (_MediaPlayerElement != value)
                {
                    SetProperty(ref _MediaPlayerElement, value);
                }
            }
        }
        public double ProgressBarLength
        {
            get { return _ProgressBarLength; }
            set
            {
                if (_ProgressBarLength != value)
                {
                    SetProperty(ref _ProgressBarLength, value);
                }
            }
        }
        public VideoItem SelectedVideo
        {
            get { return _selectedVideo; }
            set { SetProperty(ref _selectedVideo, value); }
        }
        public string MovieTitle
        {
            get { return _movieTitle; }
            set { SetProperty(ref _movieTitle, value); }
        }
        public bool DownloadIsClick
        {
            get { return downloadIsClick; }
            set { SetProperty(ref downloadIsClick, value); }
        }
        public bool MediaButtonIsClick
        {
            get { return _MediaButtonIsClick; }
            set { SetProperty(ref _MediaButtonIsClick, value); }
        }
        public string DescriptionContent
        {
            get { return descriptionContent; }
            set { SetProperty(ref descriptionContent, value); }
        }
        public Window Window { 
            get { return _window; } 
            set { SetProperty(ref _window,value); } 
        }
        public double BarLength
        {
            get { return _BarLength; }
            set
            {
                if (_BarLength != value)
                {
                    SetProperty(ref _BarLength, value);
                }
            }
        }
        public string TimeElasped
        {
            get {
                return _TimeElasped;
            }
            set {
                if (_TimeElasped != value) {
                    SetProperty(ref _TimeElasped, value);
                }
            }
        }
        public string TotalMediaTime
        {
            get { return _TotalMediaTime; }
            set {
                SetProperty(ref _TotalMediaTime, value);
            }
        }
        public Visibility SliderVisibility
        {
            get {
                return _SliderVisibility;
            }
            set {
                SetProperty(ref _SliderVisibility, value);
            }
        }
        public Visibility VinylVisibility
        {
            get { return _VinylVisibility; }
            set
            {
                 SetProperty(ref _VinylVisibility, value);
            }
        }
        public Thickness SliderPosition
        {
            get {
                return _SliderPosition;
            }
            set {
                SetProperty(ref _SliderPosition, value);
            }
        }
        public string MediaPathUrlToStored {
            get { return _MediaPathUrlToStored; }
            set { SetProperty(ref _MediaPathUrlToStored, value); }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChange?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region CONSTUCTOR
        public CenterViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitWindow();
        }

        public void InitWindow() {
            Window = Application.Current.MainWindow;

            // Set default Volume bar
            _VolumeControlHeights = new ObservableCollection<VolumeControl>();

            // set default volume bars
            _VolumeControlHeights.Add(new VolumeControl { VolumeBarHeight = 10, VolumeBarFill = VolumeBarColor });
            _VolumeControlHeights.Add(new VolumeControl { VolumeBarHeight = 20, VolumeBarFill = VolumeBarColor });
            _VolumeControlHeights.Add(new VolumeControl { VolumeBarHeight = 30, VolumeBarFill = VolumeBarColor });
            _VolumeControlHeights.Add(new VolumeControl { VolumeBarHeight = 40 });
            _VolumeControlHeights.Add(new VolumeControl { VolumeBarHeight = 50 });

            DownloadIsClick = false;
            TermCheckBoxClick = new DelegateCommand(TermClick);

            currentVolumePosition = 3;

            // set default playback play icon to play
            //_CurrentPlaybackIcon = ConvertImagePath("Play.png");

            // controls length of based based on window's size
            BarLength = 900 - 140;

            // set slider position - to be updated once media is played or user manually slides it 
            SliderPosition = new Thickness(-1, 0, 0, 0);

            MediaPlayerElement.Stretch = Stretch.Uniform;
            MediaPlayerElement.Volume = 60;

            // start time dispatcher
            DispatcherTimer Timer = new DispatcherTimer();

            // start in 1s 
            Timer.Interval = TimeSpan.FromSeconds(1);

            // tick clock 
            Timer.Tick += Timer_Tick;

            // Start clock
            Timer.Start();
        }
        #endregion

        #region COMMAND AND EVENT HANDLER
        public ICommand TermAndConditionDialog
        {
            get
            {
                return _TermAndConditionDialog ?? (_TermAndConditionDialog = new RelayCommand<object>(x =>
                {
                    GeneralDialog dialog = new GeneralDialog("Term and Condition", "Do not share this resource to not member of person..................................................................................................................................asdasdasd");
                    dialog.ShowDialog();

                }));
            }
        }
        public ICommand StopCommand
        {
            get {
                return _StopCommand ?? (_StopCommand = new RelayCommand<object>(x =>
                {
                    StopMedia();
                }));
            }
        }
        public ICommand PlayCommand {
            get {
                return _PlayCommand ?? (_PlayCommand = new RelayCommand<object>(x =>
                {
                    // only perform pause and play operation when have current media
                    if (MediaPlayerElement != null)
                    {
                        if (MediaIsPlaying)
                        {
                            MediaPlayerElement.LoadedBehavior = MediaState.Pause;
                            MediaIsPlaying = false;
                            // update playback icon
                            //_CurrentPlaybackIcon = ConvertImagePath("Play.png");

                            //// current playback menu label 
                            //_CurrentPlaybackState = "_Play";
                        }
                        else {
                            MediaPlayerElement.LoadedBehavior = MediaState.Play;
                            MediaIsPlaying = true;
                            //// update current playback icon
                            //_CurrentPlaybackIcon = ConvertImagePath("Pause.png");

                            //// update current playback menu label 
                            //_CurrentPlaybackState = "_Pause";
                        }
                    }

                    if (MediaPlayerElement.Source == null) {
                        LoadMedia();
                    }
                }));
            }
        }
        public ICommand ForwardCommand
        {
            get {
                return _ForwardCommand ?? (_ForwardCommand = new RelayCommand<object>(x =>
                {
                    // only rewind if media is available
                    if (MediaPlayerElement.IsLoaded && MediaPlayerElement.Source != null && TimeElasped != "--::--" && TotalMediaTime != "--::--") {
                        CurrentTimeSpan += 5;
                        if (CurrentTimeSpan >= TotalTimeSpan) {
                            StopMedia();
                            return;
                        }

                        MediaProgress = CalculateTimeSpan();
                        ProgressBarLength = MediaProgress;
                        SliderPosition = new Thickness(MediaProgress, 0, 0, 0);
                        MediaPlayerElement.Position = TimeSpan.FromSeconds(CurrentTimeSpan);
                    }
                }));
            }
        }
        public ICommand RewindCommand
        {
            get
            {
                return _RewindCommand ?? (_RewindCommand = new RelayCommand<object>((x) =>
                {
                    if (MediaPlayerElement.IsLoaded && MediaPlayerElement.Source != null && TimeElasped != "--::--" && TotalMediaTime != "--::--")
                    {
                        CurrentTimeSpan -= 5;
                        if (CurrentTimeSpan <= 0) CurrentTimeSpan = 0;
                        MediaProgress = CalculateTimeSpan();

                        ProgressBarLength = MediaProgress;

                        SliderPosition = new Thickness(MediaProgress, 0, 0, 0);
                        MediaPlayerElement.Position = TimeSpan.FromSeconds(CurrentTimeSpan);
                    }
                }));
            }
        }
        #endregion

        #region FUNCTION
        // Movie Function
        public void LoadMedia()
        {
            MediaPlayerElement.Source = new Uri(MediaPathUrlToStored);
            //// hide background 
            //if (_BackgroundVisibility != Visibility.Collapsed)
            //    _BackgroundVisibility = Visibility.Collapsed;

            // check if current media is an audio 
            if (Path.GetExtension(MediaPathUrlToStored) == ".mp3")
            {
                VinylVisibility = Visibility.Visible;
                MediaPlayerElement.Visibility = Visibility.Collapsed;
            }

            var placer = Path.GetExtension(MediaPathUrlToStored);
            // display media - non audio medias 
            if (MediaPlayerElement.Visibility != Visibility.Visible &&
                (placer != ".mp3"))
            {
                VinylVisibility = Visibility.Collapsed;
                MediaPlayerElement.Visibility = Visibility.Visible;
            }

            //// play current media 
            MediaPlayerElement.LoadedBehavior = MediaState.Play;

            MediaIsPlaying = true;

            //_CurrentPlaybackIcon = ConvertImagePath("Pause.png");

            //_CurrentPlaybackState = "_Pause";

            //// show media file name on title bar 
            //_MediaFileNameVisibility = Visibility.Visible;

            //// hide title bar logo
            //_LogoVisibility = Visibility.Collapsed;

            //// show progress slider 
            SliderVisibility = Visibility.Visible;
        }

       
        private void Timer_Tick(object sender, EventArgs e)
        {
            // only update progress once media is loaded and playing
            if (_MediaPlayerElement.Source != null && _MediaPlayerElement.IsLoaded == true
                && MediaIsPlaying == true && _MediaPlayerElement.NaturalDuration.HasTimeSpan == true)
            {
                CurrentTimeSpan = MediaPlayerElement.Position.TotalSeconds;
                TotalTimeSpan = MediaPlayerElement.NaturalDuration.TimeSpan.TotalSeconds;

                // compute time elasped 
                TimeSpan elasped = TimeSpan.FromSeconds(CurrentTimeSpan);

                // compute total time 
                TimeSpan total = TimeSpan.FromSeconds(TotalTimeSpan);

                // set time elasped format
                TimeElasped = FormatTime(elasped);

                // set total time format
                TotalMediaTime = FormatTime(total);

                // get current progress
                MediaProgress = CalculateTimeSpan();

                // update slider position
                if (CurrentTimeSpan >= TotalTimeSpan)
                {
                    // stop video once it is finished 
                    StopMedia();
                }

                else SliderPosition = new Thickness(MediaProgress, 0, 0, 0);

                // update progress 
                ProgressBarLength = MediaProgress;
            }
        }
        private void StopMedia()
        {
            if (MediaPlayerElement.IsLoaded && MediaPlayerElement.Source != null)
            {
                ResetMedia();

                // show media background 
                //_BackgroundVisibility = Visibility.Visible;

                // hide vinyl
                //_VinylVisibility = Visibility.Collapsed;

                // update playback icon 
                //_CurrentPlaybackIcon = ConvertImagePath("Play.png");

                //_CurrentPlaybackState = "_Play";

                // update volume labels
                TimeElasped = "--::--";
                TotalMediaTime = "--::--";

                // update progress bar 
                ProgressBarLength = .0;
                SliderPosition = new Thickness(0, 0, 0, 0);

                // hide slider 
                SliderVisibility = Visibility.Collapsed;

                //// hide media file name on title bar 
                //_MediaFileNameVisibility = Visibility.Collapsed;

                //// show title bar logo
                //_LogoVisibility = Visibility.Visible;
            }
        }

        private void ResetMedia() {
            MediaPlayerElement.LoadedBehavior = MediaState.Close;
            MediaPlayerElement.Visibility = Visibility.Collapsed;
            MediaIsPlaying = false;
            CurrentTimeSpan = 0;
            TotalTimeSpan = 0;
            MediaProgress = 0;
            MediaPlayerElement.Source = null;
        }

        // Term and Condition
        private void TermClick()
        {
            if (downloadIsClick == true)
                DownloadIsClick = false;
            else
                DownloadIsClick = true;
        }

        // General Function
        private string FormatTime(TimeSpan time)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                    time.Hours, time.Minutes, time.Seconds);
        }
        private double CalculateTimeSpan()
        {
            return (double)(CurrentTimeSpan / TotalTimeSpan) * (900 - 140);
        }

        // Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            bool isVideoExist = false;
            _eventAggregator.GetEvent<MessageSendVisibility>().Publish(Visibility.Visible);
            if (navigationContext.Parameters.ContainsKey("SelectedVideo"))
            {
                SelectedVideo = navigationContext.Parameters.GetValue<VideoItem>("SelectedVideo");
                MovieTitle = Path.GetFileNameWithoutExtension(SelectedVideo.VideoName);

                if (VideoDescriptions != null) {
                    // Filter out objects with the same video name and select the first occurrence
                    var distinctVideoDescriptions = VideoDescriptions
                        .GroupBy(vd => vd.VideoName)
                        .Select(group => group.First());
                    foreach (var description in distinctVideoDescriptions)
                    {
                        if (string.Equals(SelectedVideo.VideoName, description.VideoName, StringComparison.OrdinalIgnoreCase))
                        {
                            DescriptionContent = description.Description;
                            isVideoExist = true;
                        }   
                    }
                }
                if (isVideoExist == false || DescriptionContent == "") DescriptionContent = "No Description ...";
                MediaPathUrlToStored = SelectedVideo.VideoPath;
                LoadMedia();
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<MessageSendVisibility>().Publish(Visibility.Collapsed);
        }
        #endregion
    }
}
