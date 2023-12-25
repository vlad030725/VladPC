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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using System.Windows;

namespace VladPC.ViewModels
{
    internal class CartViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

        Notifier _notifier;

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

        private string _promoCode;
        public string PromoCode
        {
            get { return _promoCode; }
            set { _promoCode = value.ToUpper(); OnPropertyChanged(); }
        }

        private int _discount = 0;
        public int Discount
        {
            get { return _discount; }
            set { _discount = value; OnPropertyChanged(); }
        }

        public ICommand PlusProduct {  get; set; }
        public ICommand MinusProduct {  get; set; }
        public ICommand DeleteProduct {  get; set; }
        public ICommand MakeCustom { get; set; }
        public ICommand InputPromoCodeCommand { get; set; }

        public void PlusProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                if (CustomRowSelected.Count < CustomRowSelected.Product.Count)
                {
                    var SelectRow = CustomRowSelected;
                    CustomRowSelected.Count++;
                    ChangeFinalSum();
                    _customService.UpdateCustomRow(_customRowSelected);
                    OnPropertyChanged(nameof(CustomRowSelected));
                    OnPropertyChanged(nameof(CustomInCart.CustomRows));
                    CustomInCart = _customService.GetCustomInCart(IdUser);
                    CustomRowSelected = SelectRow;
                }
                else
                {
                    _notifier.ShowWarning($"Вы добавили максимально возможное количество единиц товара: {CustomRowSelected.Count}");
                }
            }
        }

        public void MinusProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                if (CustomRowSelected.Count > 1)
                {
                    var SelectRow = CustomRowSelected;
                    CustomRowSelected.Count--;
                    ChangeFinalSum();
                    _customService.UpdateCustomRow(_customRowSelected);
                    OnPropertyChanged(nameof(CustomRowSelected));
                    OnPropertyChanged(nameof(CustomInCart.CustomRows));
                    CustomInCart = _customService.GetCustomInCart(IdUser);
                    CustomRowSelected = SelectRow;
                }
            }
        }

        public void DeleteProductExecute(object obj)
        {
            if (CustomRowSelected != null)
            {
                _customService.DeleteCustomRow(CustomRowSelected.Id);
                ChangeFinalSum();
                CustomInCart = _customService.GetCustomInCart(IdUser);
            }
        }

        public void MakeCustomExecute(object obj)
        {
            CustomInCart.Sum = FinalSum;
            _customService.UpdateCustom(CustomInCart);
            _customService.MakeCustom(IdUser);
            CustomInCart = _customService.GetCustomInCart(IdUser);
            ChangeFinalSum();
        }

        private void InputPromoCode(object obj)
        {
            PromoCodeDto promo = _customService.Discount(PromoCode);

            if (promo != null)
            {
                CustomInCart.IdPromoCode = promo.Id;
                _customService.UpdateCustom(CustomInCart);

                ChangeFinalSum();

                _notifier.ShowSuccess($"Промокод успешно применён, ваша скидка {(int)(promo.Discount * 100)}%");
            }
            else
            {
                CustomInCart.IdPromoCode = null;
                _customService.UpdateCustom(CustomInCart);

                ChangeFinalSum();

                _notifier.ShowError("Промокод не найден");
            }
        }


        private void ChangeFinalSum()
        {
            FinalSum = CustomInCart.CustomRows.Select(i => (int)i.Price * (int)i.Count).Sum();
            if (_customService.Discount(CustomInCart.IdPromoCode) != null)
            {
                Discount = (int)(-1 * FinalSum * _customService.Discount(CustomInCart.IdPromoCode).Discount);
                FinalSum += Discount;
            }
            else
            {
                Discount = 0;
            }
        }

        public CartViewModel(int IdUserInput, IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;
            

            IdUser = IdUserInput;

            PlusProduct = new LambdaCommand(PlusProductExecute);
            MinusProduct = new LambdaCommand(MinusProductExecute);
            DeleteProduct = new LambdaCommand(DeleteProductExecute);
            MakeCustom = new LambdaCommand(MakeCustomExecute);
            InputPromoCodeCommand = new LambdaCommand(InputPromoCode);

            //Хардкод
            //CartProducts = new ObservableCollection<ProductDto>(_customService.GetCustom());

            CustomInCart = _customService.GetCustomInCart(IdUser);

            CustomInCart.IdPromoCode = null;

            _customService.UpdateCustom(CustomInCart);

            ChangeFinalSum();

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
