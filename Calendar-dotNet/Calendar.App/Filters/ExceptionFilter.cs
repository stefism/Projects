using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Calendar.App.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public ExceptionFilter(ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }

        public void OnException(ExceptionContext context)
        {
            //How construct a temp data here which I want to pass to error page?
            var tempData = _tempDataDictionaryFactory.GetTempData(context.HttpContext);
            tempData.Add("ErrorMessage", context.Exception.Message);

            var result = new ViewResult
            {
                ViewName = "Error",
                TempData = tempData
            };

            context.ExceptionHandled = true; // mark exception as handled
            context.Result = result;
        }
    };

}

