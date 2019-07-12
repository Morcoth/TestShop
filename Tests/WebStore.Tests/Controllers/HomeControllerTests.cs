using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.Interfaces.Api;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController homeController;


        [TestInitialize]
        public void Initialize()
        {
            homeController = new HomeController(); 
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            var result = homeController.Index();
            Assert.IsType<ViewResult>(result);

        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var result = homeController.ContactUs();
            Assert.IsType<ViewResult>(result);

        }

        [TestMethod]
        public void Blog_Returns_View()
        {
            var result = homeController.Blog();
            Assert.IsType<ViewResult>(result);

        }

        [TestMethod]
        public void BlogSingle_Returns_View()
        {
            var result = homeController.BlogSingle();
            Assert.IsType<ViewResult>(result);

        }
        [TestMethod]
        public void Error404_Returns_View()
        {
            var result = homeController.Error404();
            Assert.IsType<ViewResult>(result);

        }

        [TestMethod]
        public void ErrorStetusRedirect()
        {
            var result = homeController.ErrorStatusCode404("404");
            var redirecttoactopn = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirecttoactopn.ControllerName);
            Assert.Equal(nameof(HomeController.Error404), redirecttoactopn.ActionName);
        }


    }
}
