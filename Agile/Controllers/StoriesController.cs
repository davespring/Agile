using Agile.DAL;
using Agile.Models;
using System;
using System.Collections.Generic;
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
    }
}