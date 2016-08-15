using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.DAL
{
    public class UserSqlDAL : IUserDAL
    {
        private AgileContext db = new AgileContext();

        public List<User> GetAllUsers()
        {
            var users = db.Users.ToList();
            return users;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetUser(int userId)
        {
            var user = db.Users.Find(userId);
            return user;
        }

        public void SubscribeUser(Story story, User subscribedUser)
        {
            story.Users.Add(subscribedUser);
            subscribedUser.AddHours(story.Hours);
            db.SaveChanges();
        }
    }
}
