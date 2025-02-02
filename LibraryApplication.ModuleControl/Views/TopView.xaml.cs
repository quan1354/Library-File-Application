using Prism.Regions;
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

namespace ModuleControl.Views
{
    /// <summary>
    /// Interaction logic for TopView.xaml
    /// </summary>
    public partial class TopView : UserControl
    {
        private readonly IRegionManager _regionManager;

        public TopView(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _regionManager.RequestNavigate("CenterRegion", "HomeView");
        }
    }
}
