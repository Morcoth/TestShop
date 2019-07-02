using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class SqlOrdersService : IOrderService
    {
        private readonly WebStoreContext _db;
        private readonly UserManager<User> _UserManager;

        public SqlOrdersService(WebStoreContext db, UserManager<User> UserManager)
        {
            _db = db;
            _UserManager = UserManager;
        }

        public IEnumerable<Order> GetUserOrders(string UserName) =>
            _db.Orders
                .Include(order => order.User)
                .Include(order => order.OrderItems)
                .Where(order => order.User.UserName == UserName)
                .ToArray();

        public Order GetOrderById(int id)
        {
            return _db.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == id);
        }

        public Order CreateOrder(CreateOrderModel CartModel, string UserName)
        {
            var user = _UserManager.FindByNameAsync(UserName).Result;

            using (var transaction = _db.Database.BeginTransaction())
            {
                var order = new Order
                {
                    Name = CartModel.OrderVM.Name,
                    Address = CartModel.OrderVM.Address,
                    Phone = CartModel.OrderVM.Phone,
                    User = user,
                    Date = DateTime.Now
                };

                _db.Orders.Add(order);

                foreach (var item in CartModel.OrderItemsDTO)
                {
                    var product_model = _db.Products.FirstOrDefault(p => p.Id == item.Id);
                    var quantity = _db.Products.FirstOrDefault(p=>p.Id==product_model.Id);
                    var product = _db.Products.FirstOrDefault(p => p.Id == product_model.Id);
                    if(product is null)
                        throw new InvalidOperationException($"Товар с идентификатором {product_model.Id} в базе данных не найден");

                    var order_item = new OrderItem
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = item.Quantity,
                        Product = product
                    };

                    _db.OrderItems.Add(order_item);
                }

                _db.SaveChanges();
                transaction.Commit();

                return order;
            }
        }

        IEnumerable<CreateOrderModel> IOrderService.GetUserOrders(string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
