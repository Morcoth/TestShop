using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;
using WebStore.Services.Map;

namespace WebStore.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public PagedProductsDTO GetProducts(ProductFilter Filter)
        {
            IEnumerable<Product> products = TestData.Products;
            if (Filter?.BrandId != null)
                products = products.Where(product => product.Brand.Id == Filter.BrandId);
            if (Filter?.SectionId != null)
                products = products.Where(product => product.Section.Id == Filter.SectionId);
            return  new PagedProductsDTO { Products = ProductProductDTO.ToDTO(products) };
        }

        public ProductDTO GetProductById(int id)
        {
            var prod = TestData.Products.FirstOrDefault(product => product.Id == id);
            if (prod != null)
            {
                return new ProductDTO()
                {
                    Name = prod.Name,
                    Brand = prod.Brand is null ? null : new BrandDTO()
                    {
                        Id = prod.Brand.Id,
                        Name = prod.Brand.Name
                    },
                    Id = prod.Id,
                    ImageUrl = prod.ImageUrl,
                    Order = prod.Order,
                    Price = prod.Price
                };
            }
            else return new ProductDTO();

            }
        private WebStoreContext _db;
        private InMemoryProductData(WebStoreContext db) => _db = db;
        //IEnumerable<ProductDTO> GetProducts(ProductFilter Filter)
        //{
        //    IQueryable<Product> product = _db.Products;

        //    if (Filter.SectionId != null)
        //        product = product.Where(x => x.SectionId == Filter.SectionId);
        //    if (Filter.BrandId != null)
        //        product = product.Where(x => x.BrandId == Filter.BrandId);
        //    return product.AsEnumerable().Select(p=> new ProductDTO
        //    {
        //        Name = p.Name,
        //        Brand = p.Brand is null ? null : new BrandDTO()
        //        {
        //            Id = p.Brand.Id,
        //            Name = p.Brand.Name
        //        },
        //        Id = p.Id,
        //        ImageUrl = p.ImageUrl,
        //        Order = p.Order,
        //        Price = p.Price
        //    });

        //}

        ProductDTO IProductData.GetProductById(int id)
        {
            var x = _db.Products
                .Include(product => product.Brand)
                .Include(product => product.Section)
                .FirstOrDefault(product => product.Id == id);
            return new ProductDTO()
            {
                Name = x.Name,
                Brand = x.Brand is null ? null : new BrandDTO()
                {
                    Id = x.Brand.Id,
                    Name = x.Brand.Name
                },
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Order = x.Order,
                Price = x.Price
            };
        }

        public Section GetSectionById(int id) => TestData.Sections.FirstOrDefault(s => s.Id == id);

        public Brand GetBrandById(int id) => TestData.Brands.FirstOrDefault(b => b.Id == id);
    }
}
