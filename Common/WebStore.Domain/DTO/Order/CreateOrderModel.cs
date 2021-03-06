﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.ViewModels.Order;

namespace WebStore.Domain.DTO.Order
{
    public class CreateOrderModel: NamedEntity
    {
        public OrderViewModel OrderVM{ get; set; }
        public List<OrderItemDTO> OrderItemsDTO { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
    }

    public class OrderItemDTO : BaseEntity
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
