using ECommerceMVC.Business.Services;
using ECommerceMVC.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int addedProductId = await productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
