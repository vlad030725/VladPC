using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();

        List<ProductDto> GetAllProductsOneCustom(int Id);


        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();
    }
}
