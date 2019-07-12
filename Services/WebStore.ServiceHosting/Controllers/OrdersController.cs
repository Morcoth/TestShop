using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class OrdersController : ControllerBase, IOrderService
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{UserName}"), ActionName("post")]
        public OrderDTO CreateOrder([FromBody]CreateOrderModel CartModel, string UserName)
        {
            return _orderService.CreateOrder(CartModel, UserName);
        }
        [HttpGet("{id}"), ActionName("get")]
        public OrderDTO GetOrderById(int id)
        {
            return _orderService.GetOrderById(id);
        }
        [HttpGet("UserName"), ActionName("userorders")]

        public IEnumerable<CreateOrderModel> GetUserOrders(string UserName)
        {
            return _orderService.GetUserOrders(UserName);
        }
    }
}