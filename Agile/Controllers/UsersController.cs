using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agile.DAL;
using Agile.Models;

namespace Agile.Controllers
{
    public class UsersController : Controller
    {
        private AgileContext db = new AgileContext();

        // GET: Users
        public ActionResult ViewUsers()
        {
            //var model = db.Users.ToList();
            //var story = new Story();
            //story.Title = "TestTitle";
            //story.hours = 6;

            //model.First().Stories.Add(story);
            //db.SaveChanges();

            var model = db.Users.ToList();

            return View("ViewUsers", model);
        }


        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
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
    }
}
