using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        public OrdersClient(IConfiguration Configuration) : base(Configuration, "api/orders") { }
        
        public Order CreateOrder(CreateOrderModel CartModel, string UserName)
        {
            var response = Post($"{_ServiceAddress}/{UserName}", CartModel);
            return response.Content.ReadAsAsync<Order>().Result;


        }

        public Order GetOrderById(int id)
        {
            return Get<Order>($"{_ServiceAddress}/get/{id}");
        }

        public IEnumerable<CreateOrderModel> GetUserOrders(string UserName)
        {
            return Get<List<CreateOrderModel>>($"{_ServiceAddress}/userorders/{UserName}");
        }
    }

}

