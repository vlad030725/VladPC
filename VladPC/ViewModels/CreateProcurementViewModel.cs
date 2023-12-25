using Serilog;
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
        IReportService _reportService;

        Notifier _notifier;


        private string _priceProcStr;
        public string PriceProcStr
        {
            get { return _priceProcStr; }
            set 
            {
                int tmp = CheckValid(value, "Цена в поставке");
                _priceProcStr = tmp.ToString();
                PriceProc = tmp;
                OnPropertyChanged(); 
            }
        }

        private int _priceProc;
        public int PriceProc
        {
            get { return _priceProc; }
            set { _priceProc = value; OnPropertyChanged(); }
        }


        private string _countStr;
        public string CountStr
        {
            get { return _countStr; }
            set 
            {
                int tmp = CheckValid(value, "Количество в поставке");
                _countStr = tmp.ToString();
                Count = tmp;
                OnPropertyChanged(); 
            }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set 
            { 
                _count = value;
                OnPropertyChanged(); 
            }
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
            set 
            { 
                _productSelected = value; 
                MainWindowViewModel.IdProduct = ProductSelected == null ? null : (int?)ProductSelected.Id; 
                IsUpdate = false; 
                CountStr = "0"; 
                PriceProcStr = "0"; 
                OnPropertyChanged(); 
            }
        }

        private ProcurementDto _procurementInFilling;
        public ProcurementDto ProcurementInFilling
        {
            get { return _procurementInFilling; }
            set { _procurementInFilling = value; OnPropertyChanged(); }
        }

        private ProcurementRowDto _productSelectedInProcurement;
        public ProcurementRowDto ProductSelectedInProcurement
        {
            get { return _productSelectedInProcurement; }
            set 
            { 
                _productSelectedInProcurement = value; 
                IsUpdate = true;
                CountStr = (_productSelectedInProcurement != null ? (int)_productSelectedInProcurement.Count : 0).ToString();
                PriceProcStr = (_productSelectedInProcurement != null ? (int)_productSelectedInProcurement.Price : 0).ToString();
                OnPropertyChanged(); 
            }
        }

        private bool? _isUpdate;
        public bool? IsUpdate
        {
            get { return _isUpdate; }
            set { _isUpdate = value; OnPropertyChanged(); }
        }

        public ICommand AddInProcurementCommand { get; set; }
        public ICommand CreateProcurementCommand { get; set; }
        public ICommand DeleteProductInCatalogCommand { get; set; }
        public ICommand DeleteProductInProcurementCommand { get; set; }

        private void AddInProcurement(object obj)
        {
            if (Count == 0)
            {
                Log.Error("Count <= 0");
                _notifier.ShowError("Количество должно быть больше нуля");
                return;
            }
            if (PriceProc == 0)
            {
                Log.Error("PriceProc <= 0");
                _notifier.ShowError("Цена должна быть больше нуля");
                return;
            }
            if (IsUpdate == null)
            {
                Log.Warning("Товар не выбран <= 0");
                _notifier.ShowError("Товар не выбран");
            }
            else
            {
                if (!(bool)IsUpdate)
                {
                    if (!_procurementService.IsContainInFillingProcurement(ProductSelected.Id))
                    {
                        _procurementService.AddProcurementRow(ProductSelected, Count, PriceProc);
                        ProcurementInFilling = _procurementService.GetProcurementInFilling();
                        Log.Information("Товар добавлен в поставку");
                        _notifier.ShowSuccess("Товар добавлен в поставку");
                        if (ProductSelectedInProcurement == null)
                        {
                            IsUpdate = null;
                        }
                    }
                    else
                    {
                        Log.Information("Товар уже в поставке");
                        _notifier.ShowInformation("Товар уже в поставке");
                    }
                }
                else
                {
                    ProductSelectedInProcurement.Count = Count;
                    ProductSelectedInProcurement.Price = PriceProc;
                    _procurementService.UpdateProcurementRow(ProductSelectedInProcurement);
                    ProcurementInFilling = _procurementService.GetProcurementInFilling();
                    Log.Information("Товар в поставке обновлён");
                    _notifier.ShowSuccess("Товар в поставке обновлён");
                    if (ProductSelected == null)
                    {
                        IsUpdate = null;
                    }
                }
            }
        }

        private void CreateProcurement(object obj)
        {
            if (ProcurementInFilling.ProcurementRows.Count > 0)
            {
                
                _procurementService.AddProcurement();
                ProcurementInFilling = _procurementService.GetProcurementInFilling();
                Log.Information("Поставка добавлена");
                _notifier.ShowSuccess("Поставка добавлена");
            }
            else
            {
                Log.Information("Поставка пуста");
                _notifier.ShowError("Поставка пуста");
            }
        }

        public void DeleteProductInCatalog(object obj)
        {
            if (ProductSelected != null)
            {
                if (!_productService.IsContainInCustomsOrProcurement(ProductSelected.Id))
                {
                    _productService.DeleteProduct(ProductSelected.Id);
                    Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());
                    Log.Information("Товар удалён");
                    _notifier.ShowSuccess("Товар удалён");
                }
                else
                {
                    Log.Error("Товар не может быть удалён");
                    _notifier.ShowError("Товар не может быть удалён, так как содержится в поставке или в заказе");
                }
                
            }
            else
            {
                Log.Information("Товар не выбран");
                _notifier.ShowInformation("Товар не выбран");
            }
        }

        public void DeleteProductInProcurement(object obj)
        {
            if (ProductSelectedInProcurement != null)
            {
                _procurementService.DeleteProcurementRow(ProductSelectedInProcurement.Id);
                ProcurementInFilling = _procurementService.GetProcurementInFilling();
                Log.Information("Товар удалён");
                _notifier.ShowSuccess("Товар удалён");
            }
            else
            {
                Log.Information("Товар не выбран");
                _notifier.ShowInformation("Товар не выбран");
            }
        }

        private int CheckValid(string InputStr, string PropertyName)
        {
            string validSymbols = "1234567890";
            bool f = false;
            for (int i = 0; i < InputStr.Length; i++)
            {
                if (!validSymbols.Contains(InputStr[i]))
                {
                    InputStr = InputStr.Replace("" + InputStr[i], "");
                    Log.Error("Введены невалидные данные. Исключение обработано");
                    i--;
                    f = true;
                }
            }
            if (f)
            {
                Log.Warning("Обработка невалидных данных");
                _notifier.ShowInformation($"Поле \"{PropertyName}\" имело не корректные данные, невалидные символы убраны");
            }
            try
            {
                return Convert.ToInt32(InputStr);
            }
            catch (OverflowException)
            {
                InputStr = "0";
                _notifier.ShowError($"Указанное значение свойства \"{PropertyName}\" слишком большое");
                return Convert.ToInt32(InputStr);
            }
            catch (FormatException)
            {
                InputStr = "0";
                return Convert.ToInt32(InputStr);
            }
        }

        public CreateProcurementViewModel(IProductService productService, IProcurementService procurementService, IReportService reportService)
        {
            _productService = productService;
            _procurementService = procurementService;
            _reportService = reportService;

            Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());
            ProcurementInFilling = _procurementService.GetProcurementInFilling();

            IsUpdate = null;
            MainWindowViewModel.IdProduct = null;

            AddInProcurementCommand = new LambdaCommand(AddInProcurement);
            CreateProcurementCommand = new LambdaCommand(CreateProcurement);
            DeleteProductInCatalogCommand = new LambdaCommand(DeleteProductInCatalog);
            DeleteProductInProcurementCommand = new LambdaCommand(DeleteProductInProcurement);
            

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
