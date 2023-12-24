using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using System.Windows;

namespace VladPC.ViewModels
{
    internal class CatalogViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

        Notifier _notifier;

        private ObservableCollection<ProductDto> _products;
        public ObservableCollection<ProductDto> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        private ProductDto _productSelected;
        public ProductDto ProductSelected
        {
            get { return _productSelected; }
            set { _productSelected = value; OnPropertyChanged(); }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        public ICommand AddInCart {  get; set; }

        public void AddInCartExecute(object obj)
        {
            if (ProductSelected != null)
            {
                if (ProductSelected.Count > 0)
                {
                    if (!_customService.IsContainInCart(IdUser, ProductSelected.Id))
                    {
                        _customService.AddCustomRow(ProductSelected, IdUser);
                        _notifier.ShowSuccess("Товар добавлен в корзину");
                    }
                    else
                    {
                        _notifier.ShowInformation("Товар уже в корзине");
                    }
                }
                else
                {
                    _notifier.ShowInformation("Товара нет в наличии");
                }
            }
        }

        public CatalogViewModel(int IdUserInput, IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            IdUser = IdUserInput;

            AddInCart = new LambdaCommand(AddInCartExecute);

            Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());

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
