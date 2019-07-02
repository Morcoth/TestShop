using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain.DTO.Product;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration Configuration) : base(Configuration, "api/values") { }

        IEnumerable<Brand> IProductData.GetBrands()
        {
            return Get<List<Brand>>($"{_ServiceAddress}/GetBrands");
        }

        ProductDTO IProductData.GetProductById(int id)
        {
            return Get<ProductDTO>($"{_ServiceAddress}/Get/{id}");
        }

        IEnumerable<ProductDTO> IProductData.GetProducts(ProductFilter Filter)
        {
            var response = Post(_ServiceAddress, Filter);
            return response.Content.ReadAsAsync<IEnumerable<ProductDTO>>().Result;
        }

        IEnumerable<Section> IProductData.GetSections()
        {
            return Get<List<Section>>($"{_ServiceAddress}/GetSections");
        }
    }
}
