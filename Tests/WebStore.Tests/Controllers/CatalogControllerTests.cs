using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.Controllers;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;
namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void ProductDetails_ReturnViewWithItem()
        {
            const int expected_id = 1;
            var expected_name = $"ItemName {expected_id}";
            var expectedPrice = 10m;
            var expectedBrand = $"Brand Of Item {expected_id}";
            var productdataMock = new Mock<IProductData>();
            productdataMock.Setup(p => p.GetProductById(It.IsAny<int>())
            
            ).Returns<int>(id=>new ProductDTO()
            {
                Id = id,
                Name = $"ItemName {id}",
                Brand = new BrandDTO { Id = 1, Name = $"Brand Of Item {id }" },
                ImageUrl = $"ImageUrl{id}",
                Order = 0,
                Price = expectedPrice
            });
            var controller = new CatalogController(productdataMock.Object);


            var result = controller.ProductDetails(expected_id);


            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.ViewData.Model);
            Assert.Equal(expected_id, model.Id);
            Assert.Equal(expected_name, model.Name);
            Assert.Equal(expectedPrice, model.Price);
            Assert.Equal(expectedBrand, model.Brand);
        }

        [TestMethod]
        public void ProductDetailReturnNotFound()
        {
            var productdataMock = new Mock<IProductData>();
            productdataMock.Setup(p => p.GetProductById(It.IsAny<int>())
            ).Returns(default(ProductDTO));
            var controller = new CatalogController(productdataMock.Object);
            var result = controller.ProductDetails(1);
            Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public void ShopReturnsCorrecrView()
        {
            var productdataMock = new Mock<IProductData>();
            productdataMock.Setup(p => p.GetProducts(It.IsAny<ProductFilter>())
            ).Returns<ProductFilter>(filter => new[] 
            {
                new ProductDTO
                {
                     Id = 1,
                      Name = "Product 1",
                      Order = 0,
                       ImageUrl = "Product.png",
                        Brand = new BrandDTO{ Id = 1, Name = "NameBrand" },
                         Price = 10m
                },
                 new ProductDTO
                {
                     Id = 1,
                      Name = "Product 2",
                      Order = 0,
                       ImageUrl = "Product2.png",
                        Brand = new BrandDTO{ Id = 2, Name = "NameBrand2" },
                         Price = 10m
                },
                  new ProductDTO
                {
                     Id = 1,
                      Name = "Product 3",
                      Order = 0,
                       ImageUrl = "Produc3t.png",
                        Brand = new BrandDTO{ Id = 3, Name = "NameBrand3" },
                         Price = 10m
                }

            });

            var controller = new CatalogController(productdataMock.Object);
            const int expectedsectionid = 1;
            const int expectedbrandId = 2;

            var result = controller.Shop(expectedsectionid, expectedbrandId);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Products.Count());
            Assert.Equal(expectedbrandId, model.BrandId);
            Assert.Equal(expectedsectionid, model.SectionId);
            Assert.Equal("NameBrand", model.Products.First().Brand);

        }





    }
}
