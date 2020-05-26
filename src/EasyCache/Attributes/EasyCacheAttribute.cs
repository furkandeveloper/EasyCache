using EasyCache.Services.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace EasyCache.Attributes
{
    public class EasyCacheAttribute : Attribute, IActionFilter
    {
        public EasyCacheAttribute(Type type, string key)
        {
            this.Type = type;
            this.Key = key;
        }

        public EasyCacheAttribute(Type type, string key, Type actionResult) : this(type, key)
        {
            this.ActionResult = actionResult;
        }

        public Type Type { get; set; }
        public string Key { get; set; }

        public Type ActionResult { get; set; } = typeof(OkObjectResult);
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cacheService = context.HttpContext.RequestServices.GetService<ICacheService>();
            var data = cacheService.Get<object>(this.Key);
            if(data != null)
            {
                context.Result = (IActionResult)Activator.CreateInstance(ActionResult, args: new object[] { data });
                return;
            }
        }
    }
}
