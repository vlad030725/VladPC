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
    internal class CustomHistoryViewModel : ViewModel
    {
        IProductService _productService;
        ICustomService _customService;

        private int _idUser;
        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CustomDto> _historyCustom;
        public ObservableCollection<CustomDto> HistoryCustom
        {
            get { return _historyCustom; }
            set { _historyCustom = value; OnPropertyChanged(); }
        }

        public CustomHistoryViewModel(int IdUserInput, IProductService productService, ICustomService customService)
        {
            _productService = productService;
            _customService = customService;

            IdUser = IdUserInput;



            HistoryCustom = new ObservableCollection<CustomDto>(_customService.GetCustomHistory(IdUser));
        }
    }
}
