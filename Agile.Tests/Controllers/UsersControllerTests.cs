using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agile.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agile.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}