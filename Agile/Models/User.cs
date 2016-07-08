using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agile.Models
{
    public class User
    {
        public int totalHours = 40;

        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }


        private int hoursRemaining;
        public int HoursRemaining
        {
            get { return hoursRemaining; }
            set { hoursRemaining = totalHours; }
        }



        public virtual ICollection<Story> Stories { get; set; }


        public void AddHours(Story story)
        {
            hoursRemaining = totalHours - story.Hours;
        }

    }
}



