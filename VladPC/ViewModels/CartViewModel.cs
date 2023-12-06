using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand PlusProduct {  get; set; }
        public ICommand MinusProduct {  get; set; }

        public void PlusProductExecute([CallerMemberName] string Product = null)
        {
            
        }

        public CartViewModel(IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            //Хардкод
            CartProducts = new ObservableCollection<ProductDto>(_productService.GetAllProductsOneCustom(1));

            FinalSum = (int)CartProducts.Select(i => i.Price * i.Count).Sum();
        }
    }
}
