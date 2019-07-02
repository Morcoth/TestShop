﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _db;

        public SqlProductData(WebStoreContext DB)
        {
            _db = DB;
        }

        public IEnumerable<Section> GetSections() => _db.Sections
            .Include(s => s.Products)
            .AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _db.Brands
            .Include(brand => brand.Products)
            .AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            IQueryable<Product> products = _db.Products;
            if (Filter is null)
                return products.AsEnumerable();

            if (Filter.SectionId != null)
                products = products.Where(product => product.SectionId == Filter.SectionId);

            if (Filter.BrandId != null)
                products = products.Where(product => product.BrandId == Filter.BrandId);

            return products.AsEnumerable();
        }

        public Product GetProductById(int id) =>
            _db.Products
                .Include(product => product.Brand)
                .Include(product => product.Section)
                .FirstOrDefault(product => product.Id == id);

        IEnumerable<ProductDTO> IProductData.GetProducts(ProductFilter Filter)
        {
            throw new System.NotImplementedException();
        }

        ProductDTO IProductData.GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
