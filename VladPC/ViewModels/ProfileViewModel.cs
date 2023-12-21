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
    internal class ProfileViewModel : ViewModel
    {
        ICustomService _customService;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        public ICommand UserCustomsCommand { get; set; }
        public ICommand ProfileMainPageCommand { get; set; }

        public void UserCustoms(object obj) => CurrentView = new UserCustomsViewModel(IdUser, _customService, ref _currentView);
        public void ProfileMainPage(object obj) => CurrentView = new ProfileMainPageViewModel(IdUser, _customService, ref _currentView);

        public ProfileViewModel(int IdUserInput, ICustomService customService)
        {
            _customService = customService;

            _idUser = IdUserInput;

            UserCustomsCommand = new LambdaCommand(UserCustoms);
            ProfileMainPageCommand = new LambdaCommand(ProfileMainPage);

            CurrentView = new ProfileMainPageViewModel(IdUser, _customService, ref _currentView);

        }
    }
}
