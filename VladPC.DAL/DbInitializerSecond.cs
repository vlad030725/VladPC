using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.DAL
{
    public class DbInitializerSecond : CreateDatabaseIfNotExists<CompContext>
    {
        protected override void Seed(CompContext context)
        {
            IList<Product> ProductData = new List<Product>
            {
                new Product() { Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                //new Product() { Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                //new Product() { Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                //new Product() { Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null }
            };

            context.Product.AddRange(ProductData);

            base.Seed(context);
        }
    }
}
