using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace VladPC.BLL.DTO
{
    public class ProcurementDto
    {
        public ProcurementDto(Procurement p, List<ProcurementRowDto> thisProcurementRows)
        {
            Id = p.Id;
            CreatedDate = p.CreatedDate;
            ProcurementRows = thisProcurementRows;
            Sum = p.Sum;
        }

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Sum { get; set; }

        public List<ProcurementRowDto> ProcurementRows { get; set; }
    }
}
