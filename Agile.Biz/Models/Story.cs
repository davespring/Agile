using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.Models
{
    public class Story
    {
        public int StoryID { get; set; }
        public string Title { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
