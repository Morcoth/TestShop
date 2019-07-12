using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.Interfaces.Api;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class WebAPITestControllerTests
    {
        private WebAPITestController _Controller;
        [TestInitialize]
        public void Initialize()
        {
            var value_service_mock = new Mock<IValuesService>();
            value_service_mock.Setup(service => service.GetAsync()).ReturnsAsync(new[] { "111", "222", "333" });

            _Controller = new WebAPITestController(value_service_mock.Object);
        }

        [TestMethod]
        public async Task Index_Method_Returns_View_With_Values()
        {
            var result = await _Controller.Index();
            var viewresult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(viewresult.Model);

            const int expected_count = 3;
            Assert.Equal(expected_count, model.Count());
        }
    }
}
