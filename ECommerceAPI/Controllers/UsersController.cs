﻿using ECommerceAPI.Models;
using ECommerceMVC.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUserService userService)
        {
            this.userService = userService;
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


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Buraya tikkat burası gizli"));
                var cridential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer:"turkcell.com.tr",
                    audience:"turkcell.com.tr",
                    claims:claims,
                    notBefore: DateTime.Now,
                    expires:DateTime.Now.AddMinutes(20),
                    signingCredentials:cridential
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest(new {message = "User Name or password is wrong"});
        }
        
    }
}
