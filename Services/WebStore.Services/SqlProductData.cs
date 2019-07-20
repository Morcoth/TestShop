using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

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
            .AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _db.Brands
            .AsEnumerable();

        public PagedProductsDTO GetProducts(ProductFilter Filter)
        {
            IEnumerable<Product> products = _db.Products;


            if (Filter.SectionId != null)
                products = products.Where(product => product.SectionId == Filter.SectionId);

            if (Filter.BrandId != null)
                products = products.Where(product => product.BrandId == Filter.BrandId);

            return new PagedProductsDTO { Products = products.ToDTO(), TotalCount=products.Count() };
        }

        public ProductDTO GetProductById(int id) =>
              _db.Products
                .Include(product => product.Brand)
                .Include(product => product.Section)
              .FirstOrDefault(product => product.Id == id)?.ToDTO();

        public Section GetSectionById(int id) => _db.Sections.FirstOrDefault(s => s.Id == id);

        public Brand GetBrandById(int id) => _db.Brands.FirstOrDefault(b => b.Id == id);


    }
}
