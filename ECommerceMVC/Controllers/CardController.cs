using ECommerceMVC.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceMVC.Controllers
{
    public class CardController : Controller
    {
        private readonly IProductService productService;

        public CardController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Add(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                return Json($"{product.Name} added to basket");
            }
            return NotFound();
        }
    }
}
