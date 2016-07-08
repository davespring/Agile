using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agile.Models
{
    public class User
    {
        #region Constructors

        public User()
        {
            
        }

        #endregion

        #region Properties

        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }


        private int totalHours;
        public int TotalHours
        {
            get { return totalHours; }
            set { totalHours = 40; }
        }


        private int hoursRemaining;
        public int HoursRemaining
        {
            get { return hoursRemaining; }
            set { hoursRemaining = totalHours; }
        }



        public virtual ICollection<Story> Stories { get; set; }

        #endregion


        #region Methods

        public void AddHours(Story story)
        {
            hoursRemaining -= story.Hours;
        }

        #endregion

    }
}



