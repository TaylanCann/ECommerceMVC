using ECommerceMVC.Business.Services;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class CardController : Controller
    {
        private readonly IProductService productService;

        public CardController(IProductService productService)
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
                var product = await productService.GetProductById(id);
                CardCollection cardCollection = getCollectionFromSession(); 
                cardCollection.Add(new CardItem { Product=product, Piece=1});
                saveToSession(cardCollection);
                return Json($"{product.Name} added to basket");
            }
            return NotFound();
        }

        private void saveToSession(CardCollection cardCollection)
        {
            throw new NotImplementedException();
        }

        private CardCollection getCollectionFromSession()
        {
            CardCollection cardCollection = null;
            if (HttpContext.Session.Get("basket")==null) 
            {
                cardCollection = new CardCollection();
            }
            else
            {
                var cartCollectionJson = HttpContext.Session.GetString("myBasket");
                JsonConvert.DeserializeObject<CardCollection>(cartCollectionJson);
            }
            return cardCollection;
        }
    }
}
