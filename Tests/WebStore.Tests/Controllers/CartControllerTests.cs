using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebStore.Controllers;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void Checkout_InvalidReturnsView()
        {
            var mockCartService = new Mock<ICartService>();
            var mockOrderService = new Mock<IOrderService>();
            var controller = new CartController(mockCartService.Object, mockOrderService.Object);
            controller.ModelState.AddModelError("TestError", "InvalidModel");
            const string expectedModelName = "TestOrder";
            var result = controller.CheckOut(new OrderViewModel { Name = expectedModelName });
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<DetailsViewModel>(viewResult.ViewData.Model);
            Assert.Equal(expectedModelName, model.OrderViewModel.Name);
        }

        [TestMethod]
        public void CheckOutServiceReturnRedirect()
        {
            var mockCartService = new Mock<ICartService>();
            mockCartService.Setup(c => c.TransformCart())
                .Returns(()=>new CartViewModel {
                    Items = new Dictionary<ProductViewModel, int>
                    {
                        { new ProductViewModel(), 1 }
                    }

                });
            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(o => o.CreateOrder(It.IsAny<CreateOrderModel>(), It.IsAny<string>()))
                .Returns (new OrderDTO { Id = 1 })

                ;
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim (ClaimTypes.NameIdentifier, "1")
            }));
            var controller = new CartController(mockCartService.Object, mockOrderService.Object) {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };
            var result = controller.CheckOut(new OrderViewModel
            {
                Name = "Test",
                 Address= "",
                  Phone = ""
            });
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal(nameof(CartController.OrderConfirmed), redirectResult.ActionName);
            Assert.Equal(1, redirectResult.RouteValues["id"]);
        }



    }
}
