using EasyCache.Services.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace EasyCache.Attributes
{
    /// <summary>
    /// This Attribute providers auto cache for Controller.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AutoCacheAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="type">
        /// Cacheable object.
        /// </param>
        /// <param name="key">
        /// Cacheable key of object.
        /// </param>
        public AutoCacheAttribute(Type type, string key)
        {
            this.Type = type;
            this.Key = key;
        }

        public AutoCacheAttribute(Type type, string key, Type actionResult) : this(type, key)
        {
            this.ActionResult = actionResult;
        }

        public Type Type { get; set; }
        public string Key { get; set; }

        public Type ActionResult { get; set; } = typeof(OkObjectResult);
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var cacheService = context.HttpContext.RequestServices.GetService<ICacheService>();
            if(context.Result is ObjectResult objectResult && cacheService.Get<object>(Key) == null)
            {
                var data = objectResult.Value;

                cacheService.Set<object>(Key, data,TimeSpan.FromSeconds(30));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cacheService = context.HttpContext.RequestServices.GetService<ICacheService>();
            var data = cacheService.Get<object>(Key);
            if(data != null)
            {
                context.Result = (IActionResult)Activator.CreateInstance(ActionResult, args: new object[] { data });
                return;
            }
        }
    }
}
