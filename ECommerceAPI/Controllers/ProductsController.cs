using ECommerceAPI.Filters;
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
                return NotFound(new {message = $"Item {id} not found."});
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var addedProductId = await productService.AddProduct(request);
                return CreatedAtAction(nameof(GetProductsById), routeValues: new { id = addedProductId }, null);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [IsExist]
        public async Task<IActionResult> Update(int id,UpdateProductRequest request)
        {
          
                if (ModelState.IsValid)
                {
                    await productService.UpdateProduct(request);
                    return Ok();
                }
                return BadRequest();
          
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsExist(id))
            {
                await productService.DeleteProduct(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
