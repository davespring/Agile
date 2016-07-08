using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile.Models
{
    public class SubscribeUserViewModel
    {
        public List<User> AvailableUsers { get; set; }
        public Story StoryToSubscribe { get; set; }
    }
}