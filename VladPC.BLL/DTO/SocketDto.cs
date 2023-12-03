using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL;

namespace VladPC.BLL.DTO
{
    public class SocketDto
    {
        public SocketDto(DAL.Socket s)
        {
            Id = s.Id;
            Name = s.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
