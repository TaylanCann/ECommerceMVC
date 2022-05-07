using ECommerceMVC.Business.IServices;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
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
        public async Task<IActionResult> Login(UserLoginModel model,string returnUrl)
        {
            if (ModelState.IsValid) 
            {
                var user = await userService.ValidateUser(model.UserName,model.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim> 
                    { 
                        new Claim( ClaimTypes.Name , user.UserName ),
                        new Claim( ClaimTypes.Email , user.EMail ),
                        new Claim( ClaimTypes.Role , user.Role )

                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                }
                ModelState.AddModelError("Login", "UserName or Password wrong");
            }
            return View();

        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
