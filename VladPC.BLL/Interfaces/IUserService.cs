﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.BLL.Interfaces
{
    public interface IUserService
    {
        int? IdentificationUser(string login, string password);
    }
}
