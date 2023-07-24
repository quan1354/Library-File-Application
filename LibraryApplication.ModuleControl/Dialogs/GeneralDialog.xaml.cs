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

namespace ModuleControl.Dialogs
{
    /// <summary>
    /// Interaction logic for GeneralDialog.xaml
    /// </summary>
    public partial class GeneralDialog : Window
    {
        public GeneralDialog(string title, string msg)
        {
            InitializeComponent();

            dialogMessage.Text = msg;
            dialogTitle.Text = title;
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
