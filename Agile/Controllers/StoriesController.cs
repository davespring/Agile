using Agile.DAL;
using Agile.Models;
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

        private AgileContext db = new AgileContext();


        // GET: Stories
        public ActionResult ViewStories()
        {
            var model = db.Stories.ToList();
            return View("ViewStories", model);
        }


        [HttpPost]
        public ActionResult AddStory(Story story)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(story);
                db.SaveChanges();
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
            var model = db.Stories.Find(storyId);

            return View(model);
        }


        // Edit a story view
        [HttpGet]
        public ActionResult EditStory(int storyId)
        {
            var model = db.Stories.Find(storyId);

            return View(model);
        }

        // Edit a story action
        [HttpPost]
        public ActionResult EditStory(Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
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
            var model = db.Stories.Find(storyId);
            return View(model);
        }

        // Remove a Story
        [HttpPost]
        public ActionResult RemoveStory(Story story)
        {
            db.Stories.Remove(story);
            db.SaveChanges();
            return RedirectToAction("ViewStories");
        }
    }
}