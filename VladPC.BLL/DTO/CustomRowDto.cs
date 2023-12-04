using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.BLL.DTO
{
    public class CustomRowDto
    {
        public int Id { get; set; }

        public int? IdCustom { get; set; }

        public int? IdProduct { get; set; }

        public int? Price { get; set; }

        public int? Count { get; set; }

        public ProductDto Product { get; set; }
    }
}
