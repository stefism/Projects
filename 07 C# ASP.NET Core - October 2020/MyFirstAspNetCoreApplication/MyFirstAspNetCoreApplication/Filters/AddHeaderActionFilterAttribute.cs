using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Filters
{
    //public class AddHeaderActionFilter : IActionFilter  -така се казва класа ако ще го регистрираме глобално. Ако ще го регистрираме локално, тогава го правим на атрибут.
    public class AddHeaderActionFilterAttribute : Attribute, IActionFilter
    {        
        public void OnActionExecuting(ActionExecutingContext context) //Before action
        {
            context.HttpContext.Response.Headers.Add("X-Info-Action-Name", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context) //After action
        {
            context.HttpContext.Response.Headers.Add("X-Info-Result-Type", context.Result.GetType().Name);
        }
    }
}
