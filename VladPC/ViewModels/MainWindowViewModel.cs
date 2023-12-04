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

        public ICommand CatalogCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand ProfileCommand { get; set; }

        private void Catalog(object obj) => CurrentView = new CatalogViewModel(_productService);
        private void Cart(object obj) => CurrentView = new CartViewModel(_productService, _customService);
        private void Profile(object obj) => CurrentView = new ProfileViewModel();

        public MainWindowViewModel(IProductService productService)
        {
            //внимание хардкод
            int IdUserInput = 1;

            _productService = productService;

            CatalogCommand = new LambdaCommand(Catalog);
            CartCommand = new LambdaCommand(Cart);
            ProfileCommand = new LambdaCommand(Profile);

            CurrentView = new CatalogViewModel(_productService);
        }
    }
}
