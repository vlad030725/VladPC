using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace VladPC.BLL.DTO
{
    public class ProductDto
    {

        public ProductDto(Product p)
        {
            Name = p.Name;
            Price = p.Price;
            Count = p.Count;
            IdCompany = p.IdCompany;
            IdTypeProduct = p.IdTypeProduct;
            CountCores = p.CountCores;
            CountStreams = p.CountStreams;
            Frequency = p.Frequency;
            IdSocket = p.IdSocket;
            CountMemory = p.CountMemory;
            IdTypeMemory = p.IdTypeMemory;
            IdFormFactor = p.IdFormFactor;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Price { get; set; }

        public int? Count { get; set; }

        public int? IdCompany { get; set; }

        public int? IdTypeProduct { get; set; }

        public int? CountCores { get; set; }

        public int? CountStreams { get; set; }

        public int? Frequency { get; set; }

        public int? IdSocket { get; set; }

        public int? CountMemory { get; set; }

        public int? IdTypeMemory { get; set; }

        public int? IdFormFactor { get; set; }
    }
}
