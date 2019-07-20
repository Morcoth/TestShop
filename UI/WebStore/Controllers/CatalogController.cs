using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData, IConfiguration configuration)
        {
            _configuration = configuration;
            _ProductData = ProductData;
        }

        public IActionResult Shop(int? SectionId, int? BrandId, int Page = 1)
        {

            var page_size = int.Parse(_configuration["PageSize"]);
            var products = _ProductData.GetProducts(new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = page_size
            });

            var catalog_model = new CatalogViewModel
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Products = products.Products
                   .Select(p => new ProductViewModel
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Brand = p.Brand?.Name,
                       Order = p.Order,
                       Price = p.Price,
                       ImageUrl = p.ImageUrl
                   }),
                 PageViewModel = new PageViewModel
                 {
                      PageNumber = Page,
                       PageSize = page_size,
                       TotalItems = products.TotalCount
                 }
                //.Select(ProductViewModelMapper.CreateViewModel)
            };

            return View(catalog_model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _ProductData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Order = product.Order,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand?.Name
            });
        }
    }
}