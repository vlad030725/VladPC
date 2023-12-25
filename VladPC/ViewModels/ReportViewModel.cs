using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

using Dialog = System.Windows.Forms;

namespace VladPC.ViewModels
{
    internal class ReportViewModel : ViewModel
    {
        ICustomService _customService;
        IProcurementService _procurementService;
        IReportService _reportService;
        ILoadFileService _loadFileService;

        Notifier _notifier;

        private ObservableCollection<ReportAllTransactionsDto> _reportData;
        public ObservableCollection<ReportAllTransactionsDto> ReportData
        {
            get { return _reportData; }
            set { _reportData = value; OnPropertyChanged(); }
        }

        private DateTime _stDate = DateTime.Today.AddMonths(-1);
        public DateTime StDate
        {
            get { return _stDate; }
            set 
            { 
                _stDate = value; 
                OnPropertyChanged(); 
                ReportData = new ObservableCollection<ReportAllTransactionsDto>(_reportService.ReportProfit(StDate, EndDate, _customService.GetAllCustomsExcludeCart(), _procurementService.GetProcurementHistory()));
                FinalSum = ReportData.Select(i => i.Sum).Sum();
            }
        }

        private DateTime _endDate = DateTime.Today;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            { 
                _endDate = value; 
                OnPropertyChanged();
                ReportData = new ObservableCollection<ReportAllTransactionsDto>(_reportService.ReportProfit(StDate, EndDate, _customService.GetAllCustomsExcludeCart(), _procurementService.GetProcurementHistory()));
                FinalSum = ReportData.Select(i => i.Sum).Sum();
            }
        }

        private int _finalSum;
        public int FinalSum
        {
            get { return _finalSum; }
            set { _finalSum = value; OnPropertyChanged(); }
        }

        public ICommand ConvertToPDFCommand { get; set; }

        private void ConvertToPDF(object obj)
        {
            Dialog.SaveFileDialog menu = new Dialog.SaveFileDialog();
            menu.Filter = "txt files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (menu.ShowDialog() != Dialog.DialogResult.OK)
                return;
            string pathwithname = menu.FileName;

            string header = "header";

            _loadFileService.SaveProfitStatisticForRange(pathwithname, new List<ReportAllTransactionsDto>(ReportData), header, StDate, EndDate);
            _notifier.ShowSuccess("Отчёт PDF создан");
        }

        public ReportViewModel(ICustomService customService, IProcurementService procurementService, IReportService reportService, ILoadFileService loadFileService)
        {
            _customService = customService;
            _procurementService = procurementService;
            _reportService = reportService;
            _loadFileService = loadFileService;

            ConvertToPDFCommand = new LambdaCommand(ConvertToPDF);

            ReportData = new ObservableCollection<ReportAllTransactionsDto>(_reportService.ReportProfit(StDate, EndDate, _customService.GetAllCustomsExcludeCart(), _procurementService.GetProcurementHistory()));
            FinalSum = ReportData.Select(i => i.Sum).Sum();

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
