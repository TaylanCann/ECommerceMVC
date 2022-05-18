using ECommerceMVC.Extensions;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            var collection = HttpContext.Session.GetJson<CartCollection>("basket");
            return View(collection);
        }
    }
}
