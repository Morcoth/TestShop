﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.ViewModels.Cart;
using WebStore.Domain.ViewModels.Order;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;
        private readonly ILogger _logger;

        public CartController(ICartService CartService, IOrderService OrderService, ILogger logger)
        {
            _CartService = CartService;
            _logger = logger;
            _OrderService = OrderService;
        }
        public CartController(ICartService CartService, IOrderService OrderService)
        {
            _CartService = CartService;
            _OrderService = OrderService;
        }
        public IActionResult Details()
        {
            var model = new DetailsViewModel
            {
                CartViewModel = _CartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };
            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return RedirectToAction("Details");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new DetailsViewModel
                {
                    CartViewModel = _CartService.TransformCart(),
                    OrderViewModel = model
                });
            var createOrderModel = new CreateOrderModel()
            {
                 OrderVM = model                 

            };
            var order = _OrderService.CreateOrder( createOrderModel: createOrderModel,  User.Identity.Name);

            _CartService.RemoveAll();

            return RedirectToAction("OrderConfirmed", new { id = order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        public IActionResult AddToCartAPI(int id)
        {
            _CartService.AddToCart(id);
            return Json(new { id, message = $"Product {id} was added to cart" });
        }

        public IActionResult GetCartViewApi()
        {
            return ViewComponent("Cart");
        }
        public IActionResult DecrementFromCartAPI (int id)
        {
            _CartService.DecrementFromCart(id);
            return Json(new { id, message = $"Products {id} was decremented from cart by one" });

        }
        public IActionResult RemoveFromCartAPI(int id)
        {
            _CartService.RemoveFromCart(id);
            return Json(new { id, message = $"Products {id} was removed from cart" });

        }
        public IActionResult RemoveAllAPI()
        {
            _CartService.RemoveAll();
            return Json(new {message = $"Cart was cleaned" });

        }

    }
}