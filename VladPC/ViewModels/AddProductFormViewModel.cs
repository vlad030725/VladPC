using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class AddProductFormViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

        Notifier _notifier;

        private ObservableCollection<TypeProductDto> _typesProducts;
        public ObservableCollection<TypeProductDto> TypesProducts
        {
            get { return _typesProducts; }
            set { _typesProducts = value; OnPropertyChanged(); }
        }

        private TypeProductDto _selectedTypesProducts;
        public TypeProductDto SelectedTypesProducts
        {
            get { return _selectedTypesProducts; }
            set { _selectedTypesProducts = value; ChangeTypeProduct(); OnPropertyChanged(); }
        }

        private bool _isEnableTypeProduct;
        public bool IsEnableTypeProduct
        {
            get { return _isEnableTypeProduct; }
            set { _isEnableTypeProduct = value; OnPropertyChanged(); }
        }

        private string _nameProduct;
        public string NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CompanyDto> _companies;
        public ObservableCollection<CompanyDto> Companies
        {
            get { return _companies; }
            set { _companies = value; OnPropertyChanged(); }
        }

        private CompanyDto _selectedCompanies;
        public CompanyDto SelectedCompanies
        {
            get { return _selectedCompanies; }
            set { _selectedCompanies = value; OnPropertyChanged(); }
        }

        private string _frequencyStr = "0";
        public string FrequencyStr
        {
            get { return _frequencyStr; }
            set
            {
                int tmp = CheckValid(value, "Частота");
                _frequencyStr = tmp.ToString();
                Frequency = tmp;
                OnPropertyChanged();
            }
        }

        private int? _frequency;
        public int? Frequency
        {
            get { return _frequency; }
            set { _frequency = value; OnPropertyChanged(); }
        }

        private bool _isEnableFrequency;
        public bool IsEnableFrequency
        {
            get { return _isEnableFrequency; }
            set { _isEnableFrequency = value; OnPropertyChanged(); }
        }


        private string _countCoresStr = "0";
        public string CountCoresStr
        {
            get { return _countCoresStr; }
            set
            {
                int tmp = CheckValid(value, "Количество ядер");
                _countCoresStr = tmp.ToString();
                CountCores = tmp;
                OnPropertyChanged();
            }
        }

        private int? _countCores;
        public int? CountCores
        {
            get { return _countCores; }
            set { _countCores = value; OnPropertyChanged(); }
        }


        private string _countStreamsStr = "0";
        public string CountStreamsStr
        {
            get { return _countStreamsStr; }
            set
            {
                int tmp = CheckValid(value, "Количество потоков");
                _countStreamsStr = tmp.ToString();
                CountStreams = tmp;
                OnPropertyChanged();
            }
        }

        

        private int? _countStreams;
        public int? CountStreams
        {
            get { return _countStreams; }
            set { _countStreams = value; OnPropertyChanged(); }
        }

        private bool _isEnableCountCoresStreams;
        public bool IsEnableCountCoresStreams
        {
            get { return _isEnableCountCoresStreams; }
            set { _isEnableCountCoresStreams = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SocketDto> _sockets;
        public ObservableCollection<SocketDto> Sockets
        {
            get { return _sockets; }
            set { _sockets = value; OnPropertyChanged(); }
        }

        private SocketDto _selectedSocket;
        public SocketDto SelectedSocket
        {
            get { return _selectedSocket; }
            set { _selectedSocket = value; OnPropertyChanged(); }
        }

        private bool _isEnableSocket;
        public bool IsEnableSocket
        {
            get { return _isEnableSocket; }
            set { _isEnableSocket = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TypeMemoryDto> _typesMemory;
        public ObservableCollection<TypeMemoryDto> TypesMemory
        {
            get { return _typesMemory; }
            set { _typesMemory = value; OnPropertyChanged(); }
        }

        private TypeMemoryDto _selectedTypeMemory;
        public TypeMemoryDto SelectedTypeMemory
        {
            get { return _selectedTypeMemory; }
            set { _selectedTypeMemory = value; OnPropertyChanged(); }
        }

        private bool _isEnableTypeMemory;
        public bool IsEnableTypeMemory
        {
            get { return _isEnableTypeMemory; }
            set { _isEnableTypeMemory = value; OnPropertyChanged(); }
        }


        private string _countMemoryStr = "0";
        public string CountMemoryStr
        {
            get { return _countMemoryStr; }
            set
            {
                int tmp = CheckValid(value, "Объём памяти");
                _countMemoryStr = tmp.ToString();
                CountMemory = tmp;
                OnPropertyChanged();
            }
        }

        private int? _countMemory;
        public int? CountMemory
        {
            get { return _countMemory; }
            set { _countMemory = value; OnPropertyChanged(); }
        }

        private bool _isEnableCountMemory;
        public bool IsEnableCountMemory
        {
            get { return _isEnableCountMemory; }
            set { _isEnableCountMemory = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FormFactorDto> _formFactors;
        public ObservableCollection<FormFactorDto> FormFactors
        {
            get { return _formFactors; }
            set { _formFactors = value; OnPropertyChanged(); }
        }

        private FormFactorDto _selectedFormFactor;
        public FormFactorDto SelectedFormFactor
        {
            get { return _selectedFormFactor; }
            set { _selectedFormFactor = value; OnPropertyChanged(); }
        }

        private bool _isEnableFormFactor;
        public bool IsEnableFormFactor
        {
            get { return _isEnableFormFactor; }
            set { _isEnableFormFactor = value; OnPropertyChanged(); }
        }


        private string _priceInCatalogStr = "0";
        public string PriceInCatalogStr
        {
            get { return _priceInCatalogStr; }
            set
            {
                int tmp = CheckValid(value, "Цена в каталоге");
                _priceInCatalogStr = tmp.ToString();
                PriceInCatalog = tmp;
                OnPropertyChanged();
            }
        }

        private int _priceInCatalog;
        public int PriceInCatalog
        {
            get { return _priceInCatalog; }
            set { _priceInCatalog = value; OnPropertyChanged(); }
        }

        public ICommand NewProductCommand { get; set; }


        private void NewProduct(object obj)
        {
            ProductDto product = new ProductDto
            {
                Name = NameProduct,
                Price = PriceInCatalog,
                Count = 0,
                IdCompany = SelectedCompanies.Id,
                IdTypeProduct = SelectedTypesProducts.Id
            };

            switch (product.IdTypeProduct)
            {
                case 1:
                    product.CountCores = CountCores;
                    product.CountStreams = CountStreams;
                    product.Frequency = Frequency;
                    product.IdSocket = SelectedSocket.Id;
                    product.CountMemory = null;
                    product.IdTypeMemory = null;
                    product.IdFormFactor = null;
                    break;
                case 2:
                    product.CountCores = null;
                    product.CountStreams = null;
                    product.Frequency = Frequency;
                    product.IdSocket = null;
                    product.CountMemory = CountMemory;
                    product.IdTypeMemory = SelectedTypeMemory.Id;
                    product.IdFormFactor = null;
                    break;
                default:
                    break;
            }
            if (MainWindowViewModel.IdProduct == null)
            {
                _productService.CreateProduct(product);
                _notifier.ShowSuccess("Товар добавлен в каталог");
            }
            else
            {
                product.Id = (int)MainWindowViewModel.IdProduct;
                _productService.UpdateProduct(product);
                _notifier.ShowSuccess("Товар обновлён");
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
                    i--;
                    f = true;
                }
            }
            if (f)
            {
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

        private void ChangeTypeProduct()
        {
            switch (SelectedTypesProducts.Id)
            {
                case 1:
                    IsEnableCountCoresStreams = true;
                    CountCores = 0;
                    CountCoresStr = "0";
                    CountStreams = 0;
                    CountStreamsStr = "0";

                    IsEnableFrequency = true;
                    Frequency = 0;
                    FrequencyStr = "0";

                    IsEnableSocket = true;
                    SelectedSocket = Sockets[0];

                    IsEnableCountMemory = false;
                    CountMemory = null;
                    CountMemoryStr = "";

                    IsEnableTypeMemory = false;
                    SelectedTypeMemory = null;

                    IsEnableFormFactor = false;
                    SelectedFormFactor = null;
                    break;
                case 2:
                    IsEnableCountCoresStreams = false;
                    CountCores = null;
                    CountCoresStr = "";
                    CountStreams = null;
                    CountStreamsStr = "";

                    IsEnableFrequency = true;
                    Frequency = 0;
                    FrequencyStr = "0";

                    IsEnableSocket = false;
                    SelectedSocket = null;

                    IsEnableCountMemory = true;
                    CountMemory = 0;
                    CountMemoryStr = "0";

                    IsEnableTypeMemory = true;
                    SelectedTypeMemory = TypesMemory[0];

                    IsEnableFormFactor = false;
                    SelectedFormFactor = null;
                    break;
                default:
                    break;
            }
        }

        public AddProductFormViewModel(IProductService productService)
        {
            _productService = productService;

            Companies = new ObservableCollection<CompanyDto>(_productService.GetAllCompanies());
            //SelectedCompanies = Companies[0];

            Sockets = new ObservableCollection<SocketDto>(_productService.GetAllSockets());
            //SelectedSocket = Sockets[0];

            TypesMemory = new ObservableCollection<TypeMemoryDto>(_productService.GetAllTypesMemory());
            //SelectedTypeMemory = null;
            //IsEnableTypeMemory = false;

            FormFactors = new ObservableCollection<FormFactorDto>(_productService.GetAllFormFactors());
            //SelectedFormFactor = FormFactors[0];

            TypesProducts = new ObservableCollection<TypeProductDto>(_productService.GetAllTypesProducts());
            //SelectedTypesProducts = TypesProducts[0];
            if (MainWindowViewModel.IdProduct == null)
            {
                IsEnableTypeProduct = true;
                SelectedCompanies = Companies[0];
                SelectedSocket = Sockets[0];
                SelectedTypeMemory = null;
                IsEnableTypeMemory = false;
                SelectedFormFactor = FormFactors[0];
                SelectedTypesProducts = TypesProducts[0];
            }
            else
            {
                IsEnableTypeProduct = false;
                ProductDto product = _productService.GetProduct((int)MainWindowViewModel.IdProduct);
                //SelectedTypesProducts = _productService.GetTypeProduct((int)MainWindowViewModel.IdProduct);
                
                SelectedTypesProducts = TypesProducts.Single(i => i.Id == product.IdTypeProduct);
                ChangeTypeProduct();
                NameProduct = product.Name;
                PriceInCatalog = (int)product.Price;
                SelectedCompanies = Companies.Single(i => i.Id == product.IdCompany);
                CountCores = product.CountCores;
                CountCoresStr = CountCores.ToString();
                CountStreams = product.CountStreams;
                CountStreamsStr = CountStreams.ToString();
                Frequency = product.Frequency;
                FrequencyStr = Frequency.ToString();
                SelectedSocket = Sockets.SingleOrDefault(i => i.Id == product.IdSocket);
                CountMemory = product.CountMemory;
                SelectedTypeMemory = TypesMemory.SingleOrDefault(i => i.Id == product.IdTypeMemory);
                SelectedFormFactor = FormFactors.SingleOrDefault(i => i.Id == product.IdFormFactor);
            }

            NewProductCommand = new LambdaCommand(NewProduct);

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
