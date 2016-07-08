using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile.Models
{
    public class Subscribe
    {
        public int SubscribeID { get; set; }
        public int UserID { get; set; }
        public int StoryID { get; set; }

        public virtual User User { get; set; }
        public virtual Story Story { get; set; }

    }
}