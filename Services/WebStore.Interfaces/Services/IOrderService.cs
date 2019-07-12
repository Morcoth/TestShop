using System.Collections.Generic;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;

namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<CreateOrderModel> GetUserOrders(string UserName);

        OrderDTO GetOrderById(int id);

        OrderDTO CreateOrder(CreateOrderModel createOrderModel, string UserName);
    }
}
