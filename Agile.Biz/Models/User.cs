using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Biz.Models
{
    public class User
    {
        #region Constructors

        public User()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }

        
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

        public void AddHours(int hours)
        {
            hoursRemaining -= hours;
        }

        #endregion
    }
}
