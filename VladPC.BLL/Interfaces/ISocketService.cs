using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;

namespace VladPC.BLL.Interfaces
{
    public interface ISocketService
    {
        List<SocketDto> GetAllSockets();
    }
}
