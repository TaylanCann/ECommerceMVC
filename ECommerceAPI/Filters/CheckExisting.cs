using ECommerceMVC.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ECommerceAPI.Filters
{
    //public class IsExistAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        var idExist = context.ActionArguments.ContainsKey("id");
    //        if (!idExist)
    //        {
    //            context.Result = new BadRequestObjectResult(new { message = $"There is no parameter Id" });
    //            return;
    //        }
    //        var id =(int)context.ActionArguments["id"];
    //    }
    //}

    public class CheckExisting : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public CheckExisting(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idExist = context.ActionArguments.ContainsKey("id");
            if (!idExist)
            {
                context.Result = new BadRequestObjectResult(new { message = $"There is no parameter Id" });
            }
            else 
            {
                var id = (int)context.ActionArguments["id"];
                if (await productService.IsExist(id))
                {
                    await next.Invoke();
                }
                context.Result = new BadRequestObjectResult(new { message = $"There is no parameter Id" });
            }
        }
    }
}
