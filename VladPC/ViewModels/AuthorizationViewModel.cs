using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.BLL.Interfaces;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class AuthorizationViewModel : ViewModel
    {
        IUserService _userService;

        private string _login = "admin";
        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        private string _password = "password";
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand InputApplicationCommand { get; set; }

        private void InputApplication(object obj)
        {

        }

        public AuthorizationViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
