using ECommerceMVC.Business.IServices;
using ECommerceMVC.Business.Services;
using ECommerceMVC.Dtos.Requests;
using ECommerceMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var selectedItems = new List<SelectListItem>();
            categoryService.GetCategories().ToList().ForEach(cat => selectedItems.Add(new
                SelectListItem
            { Text = cat.Name, Value = cat.Id.ToString() }));
            ViewBag.Categories = selectedItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int addedProductId = await productService.AddProduct(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
