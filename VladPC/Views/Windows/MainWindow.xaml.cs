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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ninject;
using VladPC.BLL.Interfaces;
using VladPC.Util.Ninject;
using VladPC.ViewModels;

namespace VladPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IProductService _productService;
        ICustomService _customService;
        IUserService _userService;
        IProcurementService _procurementService;

        public MainWindow()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("CompContext"));

            _productService = kernel.Get<IProductService>();
            _customService = kernel.Get<ICustomService>();
            _userService = kernel.Get<IUserService>();
            _procurementService = kernel.Get<IProcurementService>();

            DataContext = new MainWindowViewModel(_productService, _customService, _procurementService, _userService);
        }
    }
}
