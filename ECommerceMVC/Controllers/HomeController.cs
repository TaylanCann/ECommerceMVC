using ECommerceMVC.Business;
using ECommerceMVC.Business.Services;
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
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int page=1)
        {
            var products = productService.GetProducts();

            var productPerPage = 3;

            var paginatedProducts = products.OrderBy(x => x.Id)
                                            .Skip((page - 1) * productPerPage)
                                            .Take(productPerPage);

            ViewBag.TotalPages = Math.Ceiling((decimal)products.Count / productPerPage);
            return View(paginatedProducts);

            //ProductValidator validator = new ProductValidator();
            //ValidationResult results = validator.Validate(product);
            //if (!results.IsValid)
            //{
            //    foreach (var error in results.Errors)
            //    {
            //        string errorMessage = $"{error.PropertyName} -> {error.ErrorMessage}";
            //    }
            //}
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
