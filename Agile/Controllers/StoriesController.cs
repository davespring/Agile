using Agile.Biz.DAL;
using Agile.Biz.Models;
//using Agile.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Agile.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IStoryDAL storyDal;


        public StoriesController(IStoryDAL storyDal)
        {
            this.storyDal = storyDal;
        }

        //private AgileContext db = new AgileContext();


        // GET: Stories
        public ActionResult ViewStories()
        {
            //var model = db.Stories.ToList();
            var stories = storyDal.GetAllStories();
            return View("ViewStories", stories);
        }


        [HttpPost]
        public ActionResult AddStory(Story story)
        {
            if (ModelState.IsValid)
            {
                //db.Stories.Add(story);
                //db.SaveChanges();
                storyDal.AddStory(story);
                return RedirectToAction("ViewStories", "Stories");
            }
            else
            {
                return RedirectToAction("AddStoryForm", story);
            }
        }



        // Add User Partial Form View
        public PartialViewResult AddStoryForm(Story story)
        {
            Story model = new Story();
            return PartialView("AddStoryForm", model);
        }



        // Show story details with details link and after editing
        public ActionResult StoryDetails(int storyId)
        {
            //var model = db.Stories.Find(storyId);
            var story = storyDal.GetStory(storyId);

            return View(story);
        }


        // Edit a story view
        [HttpGet]
        public ActionResult EditStory(int storyId)
        {
            //var model = db.Stories.Find(storyId);

            var story = storyDal.GetStory(storyId);
            return View(story);
        }

        // Edit a story action
        [HttpPost]
        public ActionResult EditStory(Story story)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(story).State = EntityState.Modified;
                //db.SaveChanges();
                storyDal.EditStory(story);
                return RedirectToAction("StoryDetails", new { storyId = story.StoryID });
            }
            else
            {
                return RedirectToAction("EditStory", story);
            }
        }


        // Remove Story View
        [HttpGet]
        public ActionResult RemoveStory(int storyId)
        {
            //var model = db.Stories.Find(storyId);
            var story = storyDal.GetStory(storyId);
            return View(story);
        }

        // Remove a Story
        [HttpPost]
        [ActionName("RemoveStory")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveStoryConfirmed(int storyId)
        {
            //var story = db.Stories.Find(storyId);
            //db.Stories.Remove(story);
            //db.SaveChanges();

            var story = storyDal.GetStory(storyId);
            storyDal.RemoveStory(storyId);

            return RedirectToAction("ViewStories");
            
        }
    }
}