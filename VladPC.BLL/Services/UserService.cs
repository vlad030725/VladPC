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
    public class UserService : IUserService
    {
        private IDbRepos db;

        public UserService(IDbRepos db)
        {
            this.db = db;
        }

        public int? IdentificationUser(string login, string password)
        {
            try
            {
                return db.User.GetList().Select(i => new UserDto(i)).Single(i => i.Login == login && i.Password == password).Id;
            }
            catch
            {
                return null;
            }
        }
    }
}
