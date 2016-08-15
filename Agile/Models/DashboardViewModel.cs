using Agile.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile.Models
{
    public class DashboardViewModel
    {
        public List<User> users { get; set; }
        public List<Story> stories { get; set; }
    }
}