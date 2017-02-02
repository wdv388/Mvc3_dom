using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MvcHOME.Controllers;




namespace MvcHome.Test.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private HomeController controller;
        private ViewResult result;
         [TestInitialize]
        public void SetupContext()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
        }
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            // Arrange
         //   HomeController controller = new HomeController();

            // Act
         //   ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
          
            Assert.AreEqual("Index",result.ViewName);
        }
    }
}
