using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface ILoadFileService
    {
        void SaveProfitStatisticForRange(string filename, List<ReportAllTransactionsDto> reportData, string header, DateTime StDate, DateTime EndDate);
    }
}
