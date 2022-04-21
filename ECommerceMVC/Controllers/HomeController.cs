﻿using ECommerceMVC.Business;
using ECommerceMVC.Entities;
using ECommerceMVC.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            
            var product = new List<Product>
            {
                new Product { Id = 1, Name = "MacBook Pro1" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 1, Name = "MacBook Pro1" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
                new Product { Id = 1, Name = "MacBook Pro1" , Price=20000,Discount=0.09,Description="Perfect",CategoryId=1,
                    ImageURL="https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp"},
            };
            
            //ProductValidator validator = new ProductValidator();
            //ValidationResult results = validator.Validate(product);
            //if (!results.IsValid)
            //{
            //    foreach (var error in results.Errors)
            //    {
            //        string errorMessage = $"{error.PropertyName} -> {error.ErrorMessage}";
            //    }
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
