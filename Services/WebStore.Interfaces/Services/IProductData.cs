using System.Collections.Generic;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    /// <summary>Сервис товаров</summary>
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();
        Section GetSectionById(int id);
        PagedProductsDTO GetProducts(ProductFilter Filter);
        Brand GetBrandById(int id);
        ProductDTO GetProductById(int id);



    }
}
