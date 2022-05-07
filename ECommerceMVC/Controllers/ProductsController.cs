using ECommerceMVC.Business.IServices;
using ECommerceMVC.Business.Services;
using ECommerceMVC.Dtos.Requests;
using ECommerceMVC.Dtos.Responses;
using ECommerceMVC.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> selectedItems = GetCategoriesForDropDown();

            ViewBag.Categories = selectedItems;

            return View();
        }

        private List<SelectListItem> GetCategoriesForDropDown()
        {
            var selectedItems = new List<SelectListItem>();
            categoryService.GetCategories()
                           .ToList()
                           .ForEach(cat => selectedItems.Add(
                               new SelectListItem
                               {
                                   Text = cat.Name,
                                   Value = cat.Id.ToString()
                               })
            );
            return selectedItems;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name","Price","Discount","Descripton","CategoryId","ImageURL")]AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int addedProductId = await productService.AddProduct(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            if (await productService.IsExist(id))
            {
                ProductListResponse response = await productService.GetProductById(id);
                ViewBag.Categories = GetCategoriesForDropDown();
                return View(response); 
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductRequest request) 
        {
            if (ModelState.IsValid)
            {
               int affectedRowCount = await productService.UpdateProduct(request);
                if (affectedRowCount>0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return BadRequest();
            }
            ViewBag.Categories = GetCategoriesForDropDown();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Delete2(int id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
