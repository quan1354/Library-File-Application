using LibraryApplication.Core.Events;
using LibraryApplication.ModuleControl.ViewModels;
using Prism.Events;
using System.Windows;
using System.Windows.Data;
namespace LibraryApplication.ModuleControl.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        private IEventAggregator _eventAggregator;
        public LoginDialog(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginDialogViewModel loginViewModel = new LoginDialogViewModel(UserName.Text, Password.Password);
            bool result = loginViewModel.login();
            if (result == true)
            {
                Close();
                MessageBox.Show("LOGIN SUCCESS :)");
                _eventAggregator.GetEvent<MessageSendAdminVisibility>().Publish(Visibility.Visible);
            }
            else {
                MessageBox.Show("LOGIN FAILURE :(");
            }
        }
    }
}
