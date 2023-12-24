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

        public AuthorizationViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
