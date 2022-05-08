using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            return Json("Added to basket");
        }
    }
}
