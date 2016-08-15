using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.DAL
{
    public interface IUserDAL
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        User GetUser(int userId);
        void SubscribeUser(Story story, User subscribedUser);
    }
}
