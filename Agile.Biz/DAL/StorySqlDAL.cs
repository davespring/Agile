using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.DAL
{
    public class StorySqlDAL: IStoryDAL
    {
        private AgileContext db = new AgileContext();


        public List<Story> GetAllStories()
        {
            var stories = db.Stories.ToList();
            return stories;
        }

        public Story GetStory(int storyId)
        {
            var story = db.Stories.Find(storyId);
            return story;
        }

        public void AddStory(Story story)
        {
            db.Stories.Add(story);
            db.SaveChanges();
        }

        public void EditStory(Story story)
        {
            db.Entry(story).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveStory(int storyId)
        {
            var story = db.Stories.Find(storyId);
            db.Stories.Remove(story);
            db.SaveChanges();
        }
    }
}
