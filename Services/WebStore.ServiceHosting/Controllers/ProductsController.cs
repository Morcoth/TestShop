﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ProductsController : ControllerBase, IProductData
    {
        private readonly IProductData _productData;
        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet, ActionName("GetBrands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _productData.GetBrands();
        }
        [HttpGet("{id}"), ActionName("Get")]
        public ProductDTO GetProductById(int id)
        {
            return _productData.GetProductById(id);
        }



        [HttpGet("sections/{id}")]
        public Section GetSectionById(int id) => _productData.GetSectionById(id);

        [HttpGet("brands/{id}")]
        public Brand GetBrandById(int id) => _productData.GetBrandById(id);

        [HttpPost, ActionName("Post")]
        public PagedProductsDTO GetProducts([FromBody]ProductFilter Filter)
        {
            return _productData.GetProducts(Filter);
        }



        [HttpGet, ActionName("GetSections")]
        public IEnumerable<Section> GetSections()
        {
            return _productData.GetSections();
        }
    }
}