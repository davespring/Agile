using Agile.Biz.DAL;
using Agile.Biz.Models;
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
        //private AgileContext db = new AgileContext();
        private readonly IStoryDAL storyDal;
        private readonly IUserDAL userDal;

        public HomeController(IStoryDAL storyDal, IUserDAL userDal)
        {
            this.storyDal = storyDal;
            this.userDal = userDal;
        }


        // GET: Home
        public ActionResult Index()
        {
            //var stories = db.Stories.ToList();
            //var stories = storyDal.GetAllStories();

            //return View("Index", stories);

            var stories = storyDal.GetAllStories();
            var users = userDal.GetAllUsers();

            DashboardViewModel dashModel = new DashboardViewModel();
            dashModel.stories = stories;
            dashModel.users = users;

            return View("Dashboard", dashModel);
        }


        // Subscribe User
        public ActionResult SubscribeUser(int userId, int storyId)
        {
            //int storyId = (int)TempData["storyId"];



            //Story story = db.Stories.Where(x => x.StoryID == storyId).ToList().First();
            //User subscribedUser = db.Users.Where(x => x.ID == userId).ToList().First();

            Story story = storyDal.GetStory(storyId);
            User subscribedUser = userDal.GetUser(userId);

            userDal.SubscribeUser(story, subscribedUser);

            return RedirectToAction("Index");
        }


        // Users List Modal
        
        public PartialViewResult UsersList(int storyId)
        {
            //TempData["storyId"] = storyId;

            var model = new SubscribeUserViewModel();
            model.AvailableUsers = userDal.GetAllUsers();
            //model.StoryToSubscribe = db.Stories.Where(s => s.StoryID == storyId).FirstOrDefault();
            model.StoryToSubscribe = storyDal.GetStory(storyId);
            return PartialView("UsersList", model);
        }


    }
}