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
    internal class AdminMenuViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

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
            set { _selectedTypesProducts = value; OnPropertyChanged(); }
        }

        

        private string _nameProduct;
        public string NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; OnPropertyChanged(); }
        }

        public AdminMenuViewModel(IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            TypesProducts = new ObservableCollection<TypeProductDto>(productService.GetAllTypesProducts());
            SelectedTypesProducts = TypesProducts[0];
        }
    }
}
