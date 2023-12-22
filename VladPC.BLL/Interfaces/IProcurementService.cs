﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface IProcurementService
    {
        bool IsContainInFillingProcurement(int IdProduct);

        ProcurementDto GetProcurementInFilling();

        List<ProcurementDto> GetAllProcurements();

        List<ProcurementRowDto> GetProcurementRows(int IdProcurement);

        List<CompanyDto> GetAllCompanies();

        List<SocketDto> GetAllSockets();

        List<TypeProductDto> GetAllTypesProducts();

        List<ProductDto> GetAllProducts();

        List<TypeMemoryDto> GetAllTypesMemory();

        List<FormFactorDto> GetAllFormFactors();

        void AddProcurementRow(ProductDto pr, int count, int price);
    }
}
