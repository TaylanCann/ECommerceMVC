using ECommerceMVC.Business.Services;
using ECommerceMVC.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() 
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            var product = await productService.GetProductById(id);
            if (product==null)
            {
                return NotFound(new {message = $"{id} numaralı ürün bulunamadı."});
            }
            return Ok(product);
        }

        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var addedProductId = await productService.AddProduct(request);
                return CreatedAtAction(nameof(GetProductsById), routeValues: new { id = addedProductId }, null);
            }
            return BadRequest();
        }
    }
}
