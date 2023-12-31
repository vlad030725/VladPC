﻿using System;
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

        bool IsContainInCart(int IdUser, int IdProduct);

        ProductDto GetProduct(int Id);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<ProductDto> GetAllProducts();

        List<StatusDto> GetAllStatuses();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();

        List<CustomDto> GetCustomHistory(int IdUser);

        List<CustomDto> GetAllCustomsExcludeCart();

        void UpdateCustomRow(CustomRowDto row);

        void DeleteCustomRow(int Id);

        void AddCustomRow(ProductDto row, int IdUser);

        void UpdateCustom(CustomDto custom);

        void MakeCustom(int IdUser);

        PromoCodeDto Discount(string Code);

        PromoCodeDto Discount(int? Id);
    }
}
