using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.BLL.Interfaces;
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class UserCustomsViewModel : ViewModel
    {
        ICustomService _customService;

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        private object _currentViewProfile;
        public object CurrentViewProfile
        {
            get { return _currentViewProfile; }
            set { _currentViewProfile = value; OnPropertyChanged(); }
        }

        public ICommand UserCustomsCommand { get; set; }

        public void UserCustoms(object obj) => CurrentViewProfile = new UserCustomsViewModel(IdUser, _customService, ref _currentViewProfile);

        public UserCustomsViewModel(int IdUserInput, ICustomService customService, ref object CurrentViewProfile)
        {
            _customService = customService;

            _idUser = IdUserInput;
            _currentViewProfile = CurrentViewProfile;

            UserCustomsCommand = new LambdaCommand(UserCustoms);

            CurrentViewProfile = new UserCustomsViewModel(IdUser, _customService, ref _currentViewProfile);
        }
    }
}
