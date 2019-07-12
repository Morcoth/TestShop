using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services;
using Assert = Xunit.Assert;

namespace WebStoreServices.Tests
{
    [TestClass]
    public class CookieCartServiceTests
    {
        [TestMethod]
        public void CartClassItemsCountReturnsCorrectQuantity()
        {

            const int expectedCount = 5;
            var cart = new Cart() {
                Items = new List<CartItem>
                {
                    new CartItem {ProductId = 1, Quantity = 2 },
                    new CartItem {ProductId = 2, Quantity = 3 },

                }

            };
            var result = cart.ItemsCount;
            Assert.Equal(expectedCount, result);
        }

        [TestMethod]
        public void CartViewModelCorrectItemsCount()
        {
            const int expectedCount = 6;
            var cart_view_model = new CartViewModel
            {
                 Items = new Dictionary<ProductViewModel, int>
                 {
                     { new ProductViewModel { Id = 1, Name = "Item 1",Price = 0.5m}, 1 },
                     { new ProductViewModel { Id = 2, Name = "Item 2",Price = 1.5m}, 2 },
                     { new ProductViewModel { Id = 3, Name = "Item 3",Price = 2.5m}, 3 },
                 }
            };
            var result = cart_view_model.ItemsCount;
            Assert.Equal(expectedCount, result);


        }

        [TestMethod]
        public void CarItemService_AdToCartCorrect()
        {
            var cart = new Cart
            {
                Items = new List<CartItem>()

            };
            var productdatamock = new Mock<IProductData>();
            var cartstoremock = new Mock<ICartStore>();
            cartstoremock.Setup(c => c.Cart)
                .Returns(cart);
            var cartservidse = new CookieCartService(productdatamock.Object, cartstoremock.Object);
            const int expressionId = 5;
            cartservidse.AddToCart(expressionId);
            Assert.Equal(1, cart.ItemsCount);
            Assert.Single(cart.Items);
            Assert.Equal(expressionId, cart.Items[0].ProductId);


        }

        [TestMethod]
        public void CartItemDeleteCheck()
        {
            const int itemid = 1;
            var cart = new Cart
            {
                Items = new List<CartItem>
                {
                    new CartItem{ ProductId = 1, Quantity = 1},
                    new CartItem{ ProductId = 2, Quantity = 3}
                }

            };
            var productdatamock = new Mock<IProductData>();
            var cartstoremock = new Mock<ICartStore>();
            cartstoremock.Setup(c => c.Cart)
                .Returns(cart);
            var cartservidse = new CookieCartService(productdatamock.Object, cartstoremock.Object);
            cartservidse.RemoveFromCart(itemid);

            Assert.Equal(3, cart.ItemsCount);
            Assert.Equal(2, cart.Items[0].ProductId);




        }

    }
}
