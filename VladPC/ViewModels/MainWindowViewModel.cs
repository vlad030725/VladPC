using VladPC.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.Infrastructure.Commands;
using VladPC.BLL.Interfaces;

namespace VladPC.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна

        /// <summary>
        /// Заголовок окна
        /// </summary>

        private string _title = "Магазин компьютерной техники";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Размеры окна

        public int WidthMenu { get; set; }

        private int _width = 920;
        public int Width
        {
            get => _width;
            set
            {
                Set(ref _width, value);
            }
        }

        #endregion

        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;

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

        public ICommand CatalogCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public ICommand CustomHistoryCommand { get; set; }
        public ICommand AdminMenuCommand { get; set; }
        public ICommand CreateProcurementCommand { get; set; }
        public ICommand AddProductFormCommand { get; set; }

        private void Catalog(object obj) => CurrentView = new CatalogViewModel(IdUser, _productService, _customService);
        private void Cart(object obj) => CurrentView = new CartViewModel(IdUser, _productService, _customService);
        private void Profile(object obj) => CurrentView = new ProfileViewModel(_idUser, _customService);
        private void CustomHistory(object obj) => CurrentView = new CustomHistoryViewModel(IdUser, _productService, _customService);
        private void AdminMenu(object obj) => CurrentView = new AdminMenuViewModel(_productService, _customService);
        private void CreateProcurement(object obj) => CurrentView = new CreateProcurementViewModel(_productService, _procurementService);
        private void AddProductForm(object obj) => CurrentView = new AddProductFormViewModel(_productService);

        public MainWindowViewModel(IProductService productService, ICustomService customService, IProcurementService procurementService, IUserService userService)
        {
            //внимание хардкод
            IdUser = 1;

            _productService = productService;
            _customService = customService;
            _procurementService = procurementService;
            _userService = userService;


            CatalogCommand = new LambdaCommand(Catalog);
            CartCommand = new LambdaCommand(Cart);
            ProfileCommand = new LambdaCommand(Profile);
            CustomHistoryCommand = new LambdaCommand(CustomHistory);
            AdminMenuCommand = new LambdaCommand(AdminMenu);
            CreateProcurementCommand = new LambdaCommand(CreateProcurement);
            AddProductFormCommand = new LambdaCommand(AddProductForm);

            CurrentView = new CatalogViewModel(IdUser, _productService, _customService);
        }
    }
}
