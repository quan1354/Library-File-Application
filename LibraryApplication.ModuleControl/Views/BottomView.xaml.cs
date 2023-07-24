using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for BottomView.xaml
    /// </summary>
    public partial class BottomView : UserControl
    {
        public BottomView()
        {
            InitializeComponent();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            // Change the cursor to the Hand cursor when the mouse enters the Border.
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            // Revert the cursor to the default cursor when the mouse leaves the Border.
            Mouse.OverrideCursor = null;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string Url = e.Uri.ToString();
            Process.Start(new ProcessStartInfo(Url));
            e.Handled = true;
        }
    }
}
