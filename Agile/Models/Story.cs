using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agile.Models
{
    public class Story
    {
        public int StoryID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        [StringLength(140)]
        public string Description { get; set; }


        public virtual ICollection<User> Users { get; set; }

    }
}