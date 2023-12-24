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
    internal class ProcurementHistoryViewModel : ViewModel
    {
        IProductService _productService;
        IProcurementService _procurementService;

        private ObservableCollection<ProcurementDto> _historyProcurement;
        public ObservableCollection<ProcurementDto> HistoryProcurement
        {
            get { return _historyProcurement; }
            set { _historyProcurement = value; OnPropertyChanged(); }
        }

        public ProcurementHistoryViewModel(IProductService productService, IProcurementService procurementService)
        {
            _productService = productService;
            _procurementService = procurementService;

            HistoryProcurement = new ObservableCollection<ProcurementDto>(_procurementService.GetProcurementHistory());
        }
    }
}
