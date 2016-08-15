using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.DAL
{
    public interface IStoryDAL
    {
        List<Story> GetAllStories();
        void AddStory(Story story);
        Story GetStory(int storyId);
        void EditStory(Story story);
        void RemoveStory(int storyId);

    }
}
