using ECommerceMVC.Business.Services;
using ECommerceMVC.Extensions;
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
            var cartCollection = getCollectionFromSession();
            return View(cartCollection);
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
            HttpContext.Session.SetJson("basket", cardCollection);
        }

        private CartCollection getCollectionFromSession()
        {
            CartCollection cartCollection = null;
            //if (HttpContext.Session.GetString("sepetim") == null)
            //{
            //    cartCollection = new CartCollection();
            //}

            //else
            //{
            //    var cartCollectionJson = HttpContext.Session.GetString("sepetim");
            //    cartCollection = JsonConvert.DeserializeObject<CartCollection>(cartCollectionJson);

            //}


            //if (HttpContext.Session.GetString("basket") == null) 
            //{
            //    cartCollection = new CartCollection();
            //}
            //else
            //{
            //    var cartCollectionJson = HttpContext.Session.GetString("basket");
            //    cartCollection = JsonConvert.DeserializeObject<CartCollection>(cartCollectionJson);
            //}

            cartCollection = HttpContext.Session.GetJson<CartCollection>("basket");

            return cartCollection;
        }
    }
}
