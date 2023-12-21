using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.BLL.Interfaces;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class ProfileMainPageViewModel : ViewModel
    {
        ICustomService _customService;

        private object _currentViewProfile;
        public object CurrentViewProfile
        {
            get { return _currentViewProfile; }
            set { _currentViewProfile = value; OnPropertyChanged(); }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        public ICommand UserCustomsCommand { get; set; }

        public void UserCustoms(object obj) => CurrentViewProfile = new UserCustomsViewModel(IdUser, _customService, ref _currentViewProfile);

        public ProfileMainPageViewModel(int IdUserInput, ICustomService customService, ref object CurrentViewProfile)
        {
            _customService = customService;
            
            _idUser = IdUserInput;
            _currentViewProfile = CurrentViewProfile;
        }
    }
}
