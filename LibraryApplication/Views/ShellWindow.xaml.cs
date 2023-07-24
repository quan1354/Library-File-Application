using LibraryApplication.Core.Events;
using ModuleControl.ViewModels;
using MyMovieApplication.Core.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace MyMovieApplication.Views
{
    public partial class ShellWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;
        public ShellWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<MessageSendEmpty>().Subscribe(ScrollToTop);
            Loaded += ShellWindow_Loaded;
        }

        private void ShellWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void ScrollToTop()
        {
            // Scroll the ScrollViewer to the top
            scrollViewer.ScrollToTop();
        }
    }
}
