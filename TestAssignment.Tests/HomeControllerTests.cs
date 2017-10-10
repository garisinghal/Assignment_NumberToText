using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAssignment.Controllers;
using System.Web.Mvc;

namespace TestAssignment.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        //For CorrectValues
        [TestMethod()]
        public void IndexTestForCorrectValues()
        {
            //Arrange
            HomeController _controller = new HomeController();

            // Act
            ViewResult _result = _controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Garima", _result.ViewData["Name"]);

        }
        //For No Name
        [TestMethod()]
        public void IndexTestForNoName()
        {
            Assert.Fail();
        }
        //For No Number
        [TestMethod()]
        public void IndexTestForNoNumber()
        {
            Assert.Fail();
        }
        //For IncorrectNumber
        [TestMethod()]
        public void IndexTestForIncorrectNumber()
        {
            Assert.Fail();
        }
    }
}
