using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl) 
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model,string returnUrl)
        { }
    }
}
