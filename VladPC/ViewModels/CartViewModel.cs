using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class CartViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

        private ObservableCollection<ProductDto> _cartProducts;
        public ObservableCollection<ProductDto> CartProducts
        {
            get { return _cartProducts; }
            set { _cartProducts = value; OnPropertyChanged(); }
        }

        private int _finalSum;
        public int FinalSum
        {
            get { return _finalSum; }
            set { _finalSum = value; OnPropertyChanged(); }
        }

        public CartViewModel(IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            //Хардкод
            CartProducts = new ObservableCollection<ProductDto>(_productService.GetAllProductsOneCustom(1));//_productService.GetAllProducts());//_customService.GetProductsOfCustom(1));

            FinalSum = (int)CartProducts.Select(i => i.Price * i.Count).Sum();
        }
    }
}
