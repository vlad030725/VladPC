using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class CatalogViewModel : ViewModel
    {
        IProductService _productService;

        private ObservableCollection<ProductDto> _products;
        public ObservableCollection<ProductDto> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }

        public CatalogViewModel(IProductService productService)
        {
            _productService = productService;

            Products = new ObservableCollection<ProductDto>(_productService.GetAllProducts());
            
        }
    }
}
