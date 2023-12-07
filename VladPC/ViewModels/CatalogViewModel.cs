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

namespace VladPC.ViewModels
{
    internal class CatalogViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

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

        ICommand AddInCart {  get; set; }

        public void AddInCartExecute(object obj)
        {
            if (ProductSelected != null)
            {
                _customService.AddCustomRow(ProductSelected, IdUser);
            }
        }

        public CatalogViewModel(int IdUserInput, IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            IdUser = IdUserInput;

            AddInCart = new LambdaCommand(AddInCartExecute);

            Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());
            
        }
    }
}
