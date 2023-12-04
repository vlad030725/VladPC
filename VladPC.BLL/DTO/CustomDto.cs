﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace VladPC.BLL.DTO
{
    public class CustomDto
    {
        public CustomDto(Custom c, List<ProductDto> thisCustomProducts)
        {
            Id = c.Id;
            IdUser = c.IdUser;
            IdStatus = c.IdStatus;
            Products = thisCustomProducts;
        }

        public int Id { get; set; }

        public int? Sum { get; set; }

        public int? IdUser { get; set; }

        public int? IdStatus { get; set; }

        public List<ProductDto> Products { get; set; }
        public User User { get; set; }
    }
}