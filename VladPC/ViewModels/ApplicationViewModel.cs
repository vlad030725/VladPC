using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.BLL.Interfaces;
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using System.Windows;

namespace VladPC.ViewModels
{
    internal class ApplicationViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;
        IReportService _reportService;
        ILoadFileService _loadFileService;

        Notifier _notifier;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

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

        public ICommand AuthorizationCommand { get; set; }
        public ICommand InputApplicationCommand { get; set; }

        private void Authorization(object obj) => CurrentView = new AuthorizationViewModel(_userService);
        private void InputApplication(object obj)
        {
            int? IdUserInput = _userService.IdentificationUser(Login, Password);
            if (IdUserInput != null)
            {
                CurrentView = new MainWindowViewModel((int)IdUserInput, _productService, _customService, _procurementService, _userService, _reportService, _loadFileService);
            }
            else
            {
                _notifier.ShowError("Неверное имя пользователя или пароль");
            }
        }


        public ApplicationViewModel(IProductService productService, ICustomService customService, IProcurementService procurementService, IUserService userService, IReportService reportService, ILoadFileService loadFileService)
        {
            _productService = productService;
            _customService = customService;
            _procurementService = procurementService;
            _userService = userService;
            _reportService = reportService;
            _loadFileService = loadFileService;

            AuthorizationCommand = new LambdaCommand(Authorization);
            InputApplicationCommand = new LambdaCommand(InputApplication);

            CurrentView = new AuthorizationViewModel(_userService);

            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }
    }
}
