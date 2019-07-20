﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class CartViewComponent :ViewComponent
    {
        private readonly ICartService _cartservice;

        public CartViewComponent( ICartService cartService)
        {
            _cartservice = cartService;
        }
        public IViewComponentResult Invoke() => View(_cartservice.TransformCart());
    }
}
