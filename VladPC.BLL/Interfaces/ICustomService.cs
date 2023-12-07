using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface ICustomService
    {
        CustomDto GetCustomInCart(int IdUser);

        CustomDto GetCustom(int IdCustom, int IdUser);

        List<CustomRowDto> GetCustomRowsOneCustom(int Id);

        ProductDto GetProduct(int Id);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<ProductDto> GetAllProducts();

        List<StatusDto> GetAllStatuses();

        void UpdateCustomRow(CustomRowDto row);

        void DeleteCustomRow(int Id);

        void AddCustomRow(ProductDto row, int IdUser);
    }
}
