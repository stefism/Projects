using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Calendar.App.Filters
{
    public class ActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(m => m.Errors.Select(e => e.ErrorMessage));

                throw new ArgumentException(string.Join(Environment.NewLine, errors));
            }

            await next();
        }
    }
}
