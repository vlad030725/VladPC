using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;
using VladPC.DAL;
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class CreateProcurementViewModel : ViewModel
    {
        IProductService _productService;
        IProcurementService _procurementService;

        Notifier _notifier;

        private int _priceProc;
        public int PriceProc
        {
            get { return _priceProc; }
            set { _priceProc = value; OnPropertyChanged(); }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; OnPropertyChanged(); }
        }

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

        private ProcurementDto _procurementInFilling;
        public ProcurementDto ProcurementInFilling
        {
            get { return _procurementInFilling; }
            set { _procurementInFilling = value; OnPropertyChanged(); }
        }

        public ICommand AddInProcurementCommand { get; set; }

        private void AddInProcurement(object obj)
        {
            if (ProductSelected != null)
            {
                if (!_procurementService.IsContainInFillingProcurement(ProductSelected.Id))
                {
                    _procurementService.AddProcurementRow(ProductSelected, Count, PriceProc);
                    ProcurementInFilling = ProcurementInFilling;
                    _notifier.ShowSuccess("Товар добавлен в поставку");
                }
                else
                {
                    _notifier.ShowInformation("Товар уже в поставке");
                }
            }
        }

        public CreateProcurementViewModel(IProductService productService, IProcurementService procurementService)
        {
            _productService = productService;
            _procurementService = procurementService;

            Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());
            ProcurementInFilling = _procurementService.GetProcurementInFilling();


            AddInProcurementCommand = new LambdaCommand(AddInProcurement);

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
