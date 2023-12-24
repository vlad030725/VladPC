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
    internal class ApplicationViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;
        IReportService _reportService;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand AuthorizationCommand { get; set; }
        public ICommand InputApplicationCommand { get; set; }

        private void Authorization(object obj) => CurrentView = new AuthorizationViewModel(_userService);
        private void InputApplication(object obj)
        {
            CurrentView = new MainWindowViewModel(_productService, _customService, _procurementService, _userService, _reportService);
        }


        public ApplicationViewModel(IProductService productService, ICustomService customService, IProcurementService procurementService, IUserService userService, IReportService reportService)
        {
            _productService = productService;
            _customService = customService;
            _procurementService = procurementService;
            _userService = userService;
            _reportService = reportService;

            AuthorizationCommand = new LambdaCommand(Authorization);
            InputApplicationCommand = new LambdaCommand(InputApplication);

            CurrentView = new AuthorizationViewModel(_userService);
        }
    }
}
