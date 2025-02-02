using LibraryApplication.Core.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace LibraryApplication.ModuleControl.Views
{
    public partial class CenterView_2 : UserControl
    {
        private PowerPoint.Presentation presentation;
        private readonly IEventAggregator _eventAggregator;
        public CenterView_2(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            // Register event handlers for ViewModel events
            (DataContext as ViewModels.CenterView_2_ViewModel).SlidesLoaded += OnSlidesLoaded;
            //(DataContext as ViewModels.CenterView_2_ViewModel).EnableNavigationButtons += OnEnableNavigationButtons;
        }

        private void OnSlidesLoaded(object sender, EventArgs e)
        {
            // Clear any existing slides
            slidesContainer.Items.Clear();

            var viewModel = DataContext as ViewModels.CenterView_2_ViewModel;
            var powerPointApp = new PowerPoint.Application();
            presentation = viewModel.presentation;

            try
            {
                // Display the slides in the ItemsControl
                foreach (PowerPoint.Slide slide in presentation.Slides)
                {
                    // Save the slide as an image and add it to the ItemsControl
                    string tempImagePath = System.IO.Path.GetTempFileName() + ".png";
                    slide.Export(tempImagePath, "PNG", 1024, 768);
                    BitmapImage bitmapImage = new BitmapImage(new Uri(tempImagePath));
                    var image = new Image { Source = bitmapImage, Stretch = System.Windows.Media.Stretch.Uniform };
                    slidesContainer.Items.Add(image);
                }
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
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            pdfViewer.GoToNextPage();
            _eventAggregator.GetEvent<MessageSendEmpty>().Publish();
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            pdfViewer.GoToPrevPage();
            _eventAggregator.GetEvent<MessageSendEmpty>().Publish();
        }
    }
}
