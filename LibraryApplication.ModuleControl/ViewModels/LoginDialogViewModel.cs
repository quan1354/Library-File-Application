using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryApplication.ModuleControl.ViewModels
{

    public class LoginDialogViewModel: BindableBase
    {
        private string userName { get; } = "admin@123";
        private string password { get; } = "123456";
        private string _inputUserName;
        private string _inputPassword;
        private bool _isAdmin = false;

        public bool isAdmin
        {
            get { return _isAdmin; }
            set { SetProperty(ref _isAdmin, value); }
        }

        public string InputUserName
        {
            get { return _inputUserName; }
            set { SetProperty(ref _inputUserName, value); }
        }

        public string InputPassword
        {
            get { return _inputPassword; }
            set { SetProperty(ref _inputPassword, value); }
        }
        public LoginDialogViewModel(string username, string pwd) {
            InputUserName = username;
            InputPassword = pwd;
        }

        public bool login() {
            return isAdmin = (InputUserName == userName && InputPassword == password) ? true : false;
        }
    }
}
