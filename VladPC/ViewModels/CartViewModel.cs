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
using VladPC.Infrastructure.Commands;
using VladPC.ViewModels.Base;

namespace VladPC.ViewModels
{
    internal class CartViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;



        private CustomDto _customInCart;
        public CustomDto CustomInCart
        {
            get { return _customInCart; }
            set { _customInCart = value; OnPropertyChanged(); }
        }

        private CustomRowDto _customRowSelected;
        public CustomRowDto CustomRowSelected
        {
            get { return _customRowSelected; }
            set { _customRowSelected = value; OnPropertyChanged(); }
        }

        private int _finalSum;
        public int FinalSum
        {
            get { return _finalSum; }
            set { _finalSum = value; OnPropertyChanged(); }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        public ICommand PlusProduct {  get; set; }
        public ICommand MinusProduct {  get; set; }
        public ICommand DeleteProduct {  get; set; }

        public void PlusProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                CustomRowSelected.Count++;
                //CustomInCart.CustomRows.Where(i => i.Id == CustomRowSelected.Id).Single().Id;
                CustomInCart.CustomRows[CustomInCart.CustomRows.Where(i => i.Id == CustomRowSelected.Id).Single().Id].Count = CustomRowSelected.Count;
                FinalSum = ChangeFinalSum();
                _customService.UpdateCustomRow(_customRowSelected);
                OnPropertyChanged(nameof(CustomRowSelected));
                OnPropertyChanged(nameof(FinalSum));
                OnPropertyChanged(nameof(CustomInCart.CustomRows));
            }
        }

        public void MinusProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                CustomRowSelected.Count--;
                FinalSum = ChangeFinalSum();
                _customService.UpdateCustomRow(_customRowSelected);
                OnPropertyChanged(nameof(CustomRowSelected));
                OnPropertyChanged(nameof(FinalSum));
                OnPropertyChanged(nameof(CustomInCart.CustomRows));
            }
        }

        public void DeleteProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                _customService.DeleteCustomRow(CustomRowSelected.Id);
            }
        }

        private int ChangeFinalSum()
        {
            return CustomInCart.CustomRows.Select(i => (int)i.Price * (int)i.Count).Sum();
        }

        public CartViewModel(int IdUserInput, IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            IdUser = IdUserInput;

            PlusProduct = new LambdaCommand(PlusProductExecute);
            MinusProduct = new LambdaCommand(MinusProductExecute);
            DeleteProduct = new LambdaCommand(DeleteProductExecute);

            //Хардкод
            //CartProducts = new ObservableCollection<ProductDto>(_customService.GetCustom());

            CustomInCart = _customService.GetCustomInCart(IdUser);

            FinalSum = ChangeFinalSum();
        }
    }
}
