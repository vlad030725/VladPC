using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VladPC.BLL.Interfaces;
using VladPC.Util.Ninject;
using VladPC.ViewModels;

namespace VladPC.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Application.xaml
    /// </summary>
    public partial class Application : Window
    {
        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;
        IReportService _reportService;

        public Application()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("CompContext"));

            _productService = kernel.Get<IProductService>();
            _customService = kernel.Get<ICustomService>();
            _userService = kernel.Get<IUserService>();
            _procurementService = kernel.Get<IProcurementService>();
            _reportService = kernel.Get<IReportService>();

            DataContext = new ApplicationViewModel(_productService, _customService, _procurementService, _userService, _reportService);
        }
    }
}
