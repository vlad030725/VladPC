using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL.Repository;

namespace VladPC.BLL.Services
{
    public class SocketService : ISocketService
    {
        private IDbRepos db;

        public SocketService(IDbRepos db)
        {
            this.db = db;
        }

        public List<SocketDto> GetAllSockets()
        {
            return db.Socket.GetList().Select(i => new SocketDto(i)).ToList();
        }
    }
}
