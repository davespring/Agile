using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void Add_Hours_Test()
        {

            // Arrange
            User user = new User();
            Story story = new Story();
            int expRemainingHours = 36;

            // Act
            story.Title = "TestTitle";
            story.Hours = 4;
            user.Stories.Add(story);
            user.AddHours(story);
            int actHoursRemaining = user.HoursRemaining;

            // Assert
            Assert.AreEqual(expRemainingHours, actHoursRemaining);
            Console.WriteLine(actHoursRemaining);

        }
    }
}