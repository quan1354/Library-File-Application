using LibraryApplication.ModuleControl.Dialogs;
using ModuleControl.EventHandler;
using MyMovieApplication.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;

namespace ModuleControl.ViewModels
{
    class TopViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; set; }
        private readonly IRegionManager _regionManager;
        private Visibility _btnVisibility = Visibility.Collapsed;
        private readonly IEventAggregator _eventAggregator;
        public ICommand _LoginCommand;

        public TopViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            eventAggregator.GetEvent<MessageSendVisibility>().Subscribe(onVisibility);
        }

        public ICommand LoginCommand
        {
            get
            {
                return _LoginCommand ?? (_LoginCommand = new RelayCommand<object>(x =>
                {
                    LoginDialog loginDialog = new LoginDialog(_eventAggregator);
                    loginDialog.Show();
                }));
            }
        }
        public void onVisibility(Visibility visible) {
            BtnVisibility = visible;
        }

        public Visibility BtnVisibility
        {
            get { return _btnVisibility; }
            set
            {
                if (_btnVisibility != value)
                {

                    SetProperty(ref _btnVisibility, value);
                }
            }
        }
        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate("CenterRegion", uri);
        }
    }
}
