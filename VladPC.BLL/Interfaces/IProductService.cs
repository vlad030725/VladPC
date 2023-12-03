﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts(ICompanyService companyService, ITypeProductService typeProductService, ISocketService socketService);
    }
}
