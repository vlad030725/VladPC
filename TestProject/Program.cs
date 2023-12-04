using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompContext db = new CompContext())
            {
                db.Company.Select(i => i).ToList();
                IEnumerable<Product> ProductData = new List<Product>
                {
                    new Product() { Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                    new Product() { Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null }
                };
                db.Product.AddRange(ProductData);
                db.SaveChanges();

                IEnumerable<Custom> CustomData = new List<Custom>()
                {
                    new Custom() { IdUser = 1, IdStatus = 1 }
                };
                db.Custom.AddRange(CustomData);
                db.SaveChanges();

                IEnumerable<CustomRow> CustomRowData = new List<CustomRow>()
                {
                    new CustomRow() { IdCustom = 1, IdProduct = 1, Price = 30899, Count = 1 },
                    new CustomRow() { IdCustom = 1, IdProduct = 2, Price = 12399, Count = 1 }
                };
                db.CustomRow.AddRange(CustomRowData);
                db.SaveChanges();
            }
        }
    }
}
