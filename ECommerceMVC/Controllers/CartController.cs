﻿using ECommerceMVC.Business.Services;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Add(int id)
        {
            if (await productService.IsExist(id))
            {
                //var product = null;
                var product = await productService.GetProductById(id);
                CartCollection cartCollection = getCollectionFromSession();
                CartItem newCart = new CartItem();
                newCart.Product = product;
                newCart.Piece = 1;
                cartCollection.Add(newCart);
                saveToSession(cartCollection);
                return Json($"{product.Name} added to basket");
            }
            return NotFound();
        }

        private void saveToSession(CartCollection cardCollection)
        {
            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(cardCollection));
        }

        private CartCollection getCollectionFromSession()
        {
            CartCollection cartCollection = null;
            if (HttpContext.Session.Get("basket")==null) 
            {
                cartCollection = new CartCollection();
            }
            else
            {
                var cartCollectionJson = HttpContext.Session.GetString("basket");
                JsonConvert.DeserializeObject<CartCollection>(cartCollectionJson);
            }
            return cartCollection;
        }
    }
}
