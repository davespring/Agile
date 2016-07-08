using Agile.DAL;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agile.Controllers
{
    public class HomeController : Controller
    {
        private AgileContext db = new AgileContext();

        public HomeController()
        {

        }

        // GET: Home
        public ActionResult Index()
        {
            var stories = db.Stories.ToList();

            return View("Index", stories);
        }


        // Subscribe User
        public ActionResult SubscribeUser(int userId, int storyId)
        {
            //int storyId = (int)TempData["storyId"];

            Story story = db.Stories.Where(x => x.StoryID == storyId).ToList().First();
            User subscribedUser = db.Users.Where(x => x.ID == userId).ToList().First();
            
            story.Users.Add(subscribedUser);
            subscribedUser.AddHours(story.Hours);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        // Users List Modal
        // Add User Partial Form View
        public PartialViewResult UsersList(int storyId)
        {
            //TempData["storyId"] = storyId;

            var model = new SubscribeUserViewModel();
            model.AvailableUsers = db.Users.ToList();
            model.StoryToSubscribe = db.Stories.Where(s => s.StoryID == storyId).FirstOrDefault();

            return PartialView("UsersList", model);
        }


    }
}