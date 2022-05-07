using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() 
        {
            return View();
        }
    }
}
