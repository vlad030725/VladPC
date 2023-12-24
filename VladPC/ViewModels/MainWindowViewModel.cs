﻿using VladPC.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VladPC.Infrastructure.Commands;
using VladPC.BLL.Interfaces;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using System.Windows;

namespace VladPC.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;
        IReportService _reportService;

        Notifier _notifier;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        public static int? IdProduct { get; set; }

        public ICommand CatalogCommand { get; set; }
        public ICommand CartCommand { get; set; }
        public ICommand ProfileCommand { get; set; }
        public ICommand CustomHistoryCommand { get; set; }
        public ICommand AdminMenuCommand { get; set; }
        public ICommand CreateProcurementCommand { get; set; }
        public ICommand AddProductFormCommand { get; set; }
        public ICommand ChangeProductFormCommand { get; set; }

        private void Catalog(object obj) => CurrentView = new CatalogViewModel(IdUser, _productService, _customService);
        private void Cart(object obj) => CurrentView = new CartViewModel(IdUser, _productService, _customService);
        private void Profile(object obj) => CurrentView = new ProfileViewModel(_idUser, _customService);
        private void CustomHistory(object obj) => CurrentView = new CustomHistoryViewModel(IdUser, _productService, _customService);
        private void AdminMenu(object obj) => CurrentView = new AdminMenuViewModel(_productService, _customService);
        private void CreateProcurement(object obj) => CurrentView = new CreateProcurementViewModel(_productService, _procurementService, _reportService);
        private void AddProductForm(object obj)
        {
            IdProduct = null;
            CurrentView = new AddProductFormViewModel(_productService);
        }

        private void ChangeProductForm(object obj)
        {
            if (IdProduct != null)
            {
                CurrentView = new AddProductFormViewModel(_productService);
            }
            else
            {
                _notifier.ShowInformation("Товар не выбран");
            }
        }


        public MainWindowViewModel(IProductService productService, ICustomService customService, IProcurementService procurementService, IUserService userService, IReportService reportService)
        {
            //внимание хардкод
            IdUser = 1;

            _productService = productService;
            _customService = customService;
            _procurementService = procurementService;
            _userService = userService;
            _reportService = reportService;

            CatalogCommand = new LambdaCommand(Catalog);
            CartCommand = new LambdaCommand(Cart);
            ProfileCommand = new LambdaCommand(Profile);
            CustomHistoryCommand = new LambdaCommand(CustomHistory);
            AdminMenuCommand = new LambdaCommand(AdminMenu);
            CreateProcurementCommand = new LambdaCommand(CreateProcurement);
            AddProductFormCommand = new LambdaCommand(AddProductForm);
            ChangeProductFormCommand = new LambdaCommand(ChangeProductForm);

            CurrentView = new CatalogViewModel(IdUser, _productService, _customService);

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
