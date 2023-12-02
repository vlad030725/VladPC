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
                new Company() { Name = "AMD" }
            };

            context.Company.AddRange(CompanyData);

            IList<User> UserData = new List<User>
            {
                new User() { Name = "admin", Login = "admin", Password = "password" },
                new User() { Name = "Юдин Владислав Сергеевич", Login = "vlad030725", Password = "1234" }
            };

            context.User.AddRange(UserData);

            IList<TypeProduct> TypeProductData = new List<TypeProduct>
            {
                new TypeProduct() { Name = "Processor" },
                new TypeProduct() { Name = "GraphicsCard" }
            };

            context.TypeProduct.AddRange(TypeProductData);

            IList<Socket> SocketData = new List<Socket>
            {
                new Socket() { Name = "LGA1700" },
                new Socket() { Name = "LGA1200" },
                new Socket() { Name = "AM4" }
            };

            context.Socket.AddRange(SocketData);

            base.Seed(context);
        }
    }
}
