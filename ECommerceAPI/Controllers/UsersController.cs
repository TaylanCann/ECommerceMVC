using ECommerceAPI.Models;
using ECommerceMVC.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMemoryCache cache;

        public UsersController(IUserService userService, IMemoryCache cache)
        {
            this.userService = userService;
            this.cache = cache;
        }

        [HttpPost]
       public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await userService.ValidateUser(model.UserName, model.Password);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),

                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Buraya dikkat burası gizli"));
                var cridential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                
                var isInCache = cache.TryGetValue("userCache", out JwtSecurityToken cachedToken);
                if (isInCache == false)
                {
                    var token = new JwtSecurityToken(
                    issuer: "turkcell.com.tr",
                    audience: "turkcell.com.tr",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: cridential
                    );

                    cachedToken = token;
                    cache.Set("userCache", token, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5) 
                    }) ;
                }

                cache.GetOrCreate("alternative", entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                    return new[] { "A", "B", "C" };
                });

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(cachedToken) });
            }
            return BadRequest(new {message = "User Name or password is wrong"});
        }
        [HttpGet("[action]")]
        public IActionResult GetCache()
        {
            return Ok(cache.Get("alternative"));
        }
    }
}
