using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<CompContext>
    {
        protected override void Seed(CompContext context)
        {
            IList<Company> CompanyData = new List<Company>
            {
                new Company() { Name = "Intel" },
                new Company() { Name = "AMD" },
                new Company() { Name = "NVidia" }
            };

            context.Company.AddRange(CompanyData);

            IList<User> UserData = new List<User>
            {
                new User() { Name = "admin", Login = "admin", Password = "password" },
                new User() { Name = "Юдин Владислав Сергеевич", Login = "vlad030725", Password = "1234" },
                new User() { Name = "Дядя Фридрих", Login = "Fridrih", Password = "1234" }
            };

            context.User.AddRange(UserData);

            IList<TypeProduct> TypeProductData = new List<TypeProduct>
            {
                new TypeProduct() { Name = "Процессор" },
                new TypeProduct() { Name = "Видеокарта" }
            };

            context.TypeProduct.AddRange(TypeProductData);

            IList<Socket> SocketData = new List<Socket>
            {
                new Socket() { Name = "LGA1700" },
                new Socket() { Name = "LGA1200" },
                new Socket() { Name = "AM5" },
                new Socket() { Name = "AM3+" },
                new Socket() { Name = "LGA 1151-v2" },
                new Socket() { Name = "LGA 1151" },
                new Socket() { Name = "LGA 2066" },
                new Socket() { Name = "sWRX8" },
                new Socket() { Name = "AM4" },
            };

            context.Socket.AddRange(SocketData);

            IList<Status> StatusData = new List<Status>
            {
                new Status() { Name = "В корзине" },
                new Status() { Name = "В пути" },
                new Status() { Name = "Готов к выдачи" },
                new Status() { Name = "Получен" }
            };

            context.Status.AddRange(StatusData);

            IList<TypeMemory> TypeMemoryData = new List<TypeMemory>()
            {
                new TypeMemory() { Name = "GDDR5" },
                new TypeMemory() { Name = "GDDR6" },
                new TypeMemory() { Name = "GDDR6X" },
                new TypeMemory() { Name = "DDR5" },
                new TypeMemory() { Name = "DDR4" },
                new TypeMemory() { Name = "DDR3" },
            };

            context.TypeMemory.AddRange(TypeMemoryData);

            IList<FormFactor> FormFactorData = new List<FormFactor>()
            {
                new FormFactor() { Name = "Standart-ATX" },
                new FormFactor() { Name = "mini-ATX" },
                new FormFactor() { Name = "micro-ATX" },
            };

            context.FormFactor.AddRange(FormFactorData);

            IList<PromoCode> PromoCodeData = new List<PromoCode>()
            {
                new PromoCode() { Code = "POLTOS", Discount = 0.05 }
            };

            context.PromoCode.AddRange(PromoCodeData);

            context.SaveChanges();

            IList<Product> ProductData = new List<Product>
            {
                new Product() { Name = "i7-11700F", Price = 30899, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 2500, IdSocket = 2, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                new Product() { Name = "i3-13100F", Price = 12399, Count = 3, IdCompany = 1, IdTypeProduct = 1, CountCores = 4, CountStreams = 8, Frequency = 3400, IdSocket = 1, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                new Product() { Name = "Ryzen 7 5800X3D", Price = 36799, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 8, CountStreams = 16, Frequency = 3400, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                new Product() { Name = "Ryzen 3 3200G", Price = 9099, Count = 2, IdCompany = 2, IdTypeProduct = 1, CountCores = 4, CountStreams = 4, Frequency = 3600, IdSocket = 3, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                new Product() { Name = "Ryzen Threadripper PRO 5995WX", Price = 714999, Count = 1, IdCompany = 2, IdTypeProduct = 1, CountCores = 64, CountStreams = 64, Frequency = 2700, IdSocket = 8, CountMemory = null, IdTypeMemory = null, IdFormFactor = null },
                new Product() { Name = "GeForce RTX 4060 Ti", Price = 43499, Count = 4, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2310, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
                new Product() { Name = "GeForce RTX 4090", Price = 199999, Count = 2, IdCompany = 3, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2230, IdSocket = null, CountMemory = 24, IdTypeMemory = 3, IdFormFactor = null },
                new Product() { Name = "Arc A770", Price = 30999, Count = 4, IdCompany = 1, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2100, IdSocket = null, CountMemory = 8, IdTypeMemory = 2, IdFormFactor = null },
                new Product() { Name = "Radeon RX 7800 XT", Price = 65999, Count = 1, IdCompany = 2, IdTypeProduct = 2, CountCores = null, CountStreams = null, Frequency = 2430, IdSocket = null, CountMemory = 16, IdTypeMemory = 2, IdFormFactor = null },
            };

            context.Product.AddRange(ProductData);

            context.SaveChanges();

            IList<Custom> CustomData = new List<Custom>()
            {
                new Custom() { IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-3), Sum = 0 },
                new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-5), Sum = 0 },
                new Custom() { IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
                new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
                new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 },
                new Custom() { IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-13), Sum = 0 },
                new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-14), Sum = 0 },
                new Custom() { IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-15), Sum = 0 },
                new Custom() { IdUser = 3, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-19), Sum = 0 },
                new Custom() { IdUser = 2, IdStatus = 3, IdPromoCode = null, CreatedDate = DateTime.Now.AddDays(-30), Sum = 0 },
            };

            IList<CustomRow> CustomRowData = new List<CustomRow>()
            {
                new CustomRow() { IdCustom = 1, IdProduct = 1, Price = 32899, Count = 1 },
                new CustomRow() { IdCustom = 1, IdProduct = 6, Price = 43499, Count = 1 },
                new CustomRow() { IdCustom = 2, IdProduct = 5, Price = 714999, Count = 1 },
                new CustomRow() { IdCustom = 3, IdProduct = 2, Price = 12399, Count = 10 },
                new CustomRow() { IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
                new CustomRow() { IdCustom = 4, IdProduct = 2, Price = 12399, Count = 1 },
                new CustomRow() { IdCustom = 4, IdProduct = 4, Price = 10099, Count = 1 },
                new CustomRow() { IdCustom = 4, IdProduct = 8, Price = 29999, Count = 1 },
                new CustomRow() { IdCustom = 4, IdProduct = 6, Price = 43499, Count = 2 },
                new CustomRow() { IdCustom = 5, IdProduct = 7, Price = 210999, Count = 1 },
                new CustomRow() { IdCustom = 6, IdProduct = 1, Price = 32899, Count = 1 },
                new CustomRow() { IdCustom = 6, IdProduct = 6, Price = 43499, Count = 1 },
                new CustomRow() { IdCustom = 7, IdProduct = 5, Price = 714999, Count = 1 },
                new CustomRow() { IdCustom = 8, IdProduct = 2, Price = 12399, Count = 10 },
                new CustomRow() { IdCustom = 9, IdProduct = 2, Price = 12399, Count = 1 },
                new CustomRow() { IdCustom = 9, IdProduct = 2, Price = 12399, Count = 1 },
                new CustomRow() { IdCustom = 9, IdProduct = 4, Price = 10099, Count = 1 },
                new CustomRow() { IdCustom = 9, IdProduct = 8, Price = 29999, Count = 1 },
                new CustomRow() { IdCustom = 9, IdProduct = 6, Price = 43499, Count = 2 },
                new CustomRow() { IdCustom = 10, IdProduct = 7, Price = 210999, Count = 1 }
            };

            for (int i = 0; i < CustomData.Count; i++)
            {
                for (int j = 0; j < CustomRowData.Count; j++)
                {
                    if (CustomRowData[j].IdCustom == i + 1)
                    {
                        CustomData[i].Sum += CustomRowData[j].Count * CustomRowData[j].Price;
                    }
                }
            }

            context.Custom.AddRange(CustomData);

            context.SaveChanges();

            context.CustomRow.AddRange(CustomRowData);

            IList<Procurement> ProcurementData = new List<Procurement>()
            {
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-4), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-6), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-7), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-8), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-9), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-11), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-12), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-13), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-16), Sum = 0 },
                new Procurement() { CreatedDate = DateTime.Now.AddDays(-25), Sum = 0 },
            };

            IList<ProcurementRow> ProcurementRowData = new List<ProcurementRow>()
            {
                new ProcurementRow() { IdProcurement = 1, IdProduct = 1, Price = 30899, Count = 1 },
                new ProcurementRow() { IdProcurement = 1, IdProduct = 6, Price = 40499, Count = 6 },
                new ProcurementRow() { IdProcurement = 2, IdProduct = 5, Price = 690999, Count = 1 },
                new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 9399, Count = 2 },
                new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 9499, Count = 2 },
                new ProcurementRow() { IdProcurement = 3, IdProduct = 2, Price = 11399, Count = 2 },
                new ProcurementRow() { IdProcurement = 4, IdProduct = 4, Price = 8099, Count = 4 },
                new ProcurementRow() { IdProcurement = 5, IdProduct = 8, Price = 32999, Count = 8 },
                new ProcurementRow() { IdProcurement = 5, IdProduct = 6, Price = 41499, Count = 6 },
                new ProcurementRow() { IdProcurement = 6, IdProduct = 7, Price = 200999, Count = 7 },
                new ProcurementRow() { IdProcurement = 6, IdProduct = 1, Price = 30899, Count = 1 },
                new ProcurementRow() { IdProcurement = 6, IdProduct = 6, Price = 44499, Count = 6 },
                new ProcurementRow() { IdProcurement = 6, IdProduct = 5, Price = 660999, Count = 1 },
                new ProcurementRow() { IdProcurement = 7, IdProduct = 2, Price = 11399, Count = 2 },
                new ProcurementRow() { IdProcurement = 7, IdProduct = 2, Price = 11399, Count = 2 },
                new ProcurementRow() { IdProcurement = 8, IdProduct = 2, Price = 10399, Count = 2 },
                new ProcurementRow() { IdProcurement = 9, IdProduct = 4, Price = 7099, Count = 4 },
                new ProcurementRow() { IdProcurement = 9, IdProduct = 8, Price = 27999, Count = 8 },
                new ProcurementRow() { IdProcurement = 10, IdProduct = 6, Price = 47499, Count = 6 },
                new ProcurementRow() { IdProcurement = 10, IdProduct = 7, Price = 205999, Count = 7 }
            };

            for (int i = 0; i < ProcurementData.Count; i++)
            {
                for (int j = 0; j < ProcurementRowData.Count; j++)
                {
                    if (ProcurementRowData[j].IdProcurement == i + 1)
                    {
                        ProcurementData[i].Sum += ProcurementRowData[j].Count * ProcurementRowData[j].Price;
                    }
                }
            }

            context.Procurement.AddRange(ProcurementData);

            context.SaveChanges();

            context.ProcurementRow.AddRange(ProcurementRowData);

            base.Seed(context);
        }
    }
}
