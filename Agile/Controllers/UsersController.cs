using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using Agile.DAL;
using Agile.Models;
using Agile.Biz.DAL;
using Agile.Biz.Models; 

namespace Agile.Controllers
{
    public class UsersController : Controller
    {


        private readonly IUserDAL userDal;


        public UsersController(IUserDAL userDal)
        {
            this.userDal = userDal;
        }

        // Previous Working Code
        //private AgileContext db = new AgileContext();

        // GET: Users
        public ActionResult ViewUsers()
        {

            //var model = db.Users.ToList();

            var model = userDal.GetAllUsers();

            return View("ViewUsers", model);
        }


        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                //db.Users.Add(user);
                //db.SaveChanges();
                userDal.AddUser(user);
                return RedirectToAction("ViewUsers", "Users");
            }
            else
            {
                return RedirectToAction("AddUserForm", user);
            }
        }

        // Add User Partial Form View
        public PartialViewResult AddUserForm(User user)
        {
            User model = new User();
            return PartialView("AddUserForm", model);
        }


        // Search for a user
        public ActionResult SearchUser()
        {
            SearchUserViewModel model = new SearchUserViewModel();

            //model.AvailableUsers = db.Users.ToList();

            model.AvailableUsers = userDal.GetAllUsers();

            return View("SearchUser", model);

        }

        [HttpGet]
        public ActionResult SearchUser(int userId)
        {
            //var model = db.Users;
            //var user = model.Where(x => x.UserName == username).FirstOrDefault();

            var user = userDal.GetUser(userId);
            return View("ViewUsers", user);
        }
    }
}
