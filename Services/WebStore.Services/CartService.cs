using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.Domain.Entities;
using WebStore.Domain.Models;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class CookieCartService : ICartService
    {
        public ICartStore _CartStore;

        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string _CartName;



        public CookieCartService(IProductData ProductData, ICartStore cartStore)
        {
            _CartStore = cartStore;
            _ProductData = ProductData;


        }

        public void DecrementFromCart(int id)
        {
            var cart = _CartStore.Cart;

            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item != null)
            {
                if (item.Quantity > 0)
                    item.Quantity--;
                if (item.Quantity == 0)
                    cart.Items.Remove(item);

                _CartStore.Cart = cart;
            }
        }

        public void RemoveFromCart(int id)
        {
            var cart = _CartStore.Cart;

            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
            {
                cart.Items.Remove(item);
                _CartStore.Cart = cart;
            }
        }

        public void RemoveAll()
        {
            var cart = _CartStore.Cart;
            cart.Items.Clear();
            _CartStore.Cart = cart;
        }

        public void AddToCart(int id)
        {
            var cart = _CartStore.Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item != null)
                item.Quantity++;
            else
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            _CartStore.Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                Ids = _CartStore.Cart.Items.Select(item => item.ProductId).ToList()
            });

            var products_view_models = products.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Brand = p.Brand?.Name
            });

            return new CartViewModel
            {
                Items = _CartStore.Cart.Items.ToDictionary(
                    x => products_view_models.First(p => p.Id == x.ProductId), 
                    x => x.Quantity)
            };

        }
    }
}
