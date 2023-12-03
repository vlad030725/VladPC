using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace VladPC.BLL.DTO
{
    public class CompanyDto
    {
        public CompanyDto(Company c)
        {
            Name = c.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
