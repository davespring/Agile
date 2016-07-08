using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agile.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void Index_Action_Renders_Default_View()
        {

            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            

        }
    }
}