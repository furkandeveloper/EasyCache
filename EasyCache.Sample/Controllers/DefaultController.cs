using EasyCache.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCache.Sample.Controllers
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ICacheService cacheService;

        public DefaultController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        //private readonly IDistributedCache distributedCache;
        //public DefaultController(IDistributedCache distributedCache)
        //{
        //    this.distributedCache = distributedCache;
        //}

        [HttpGet("[controller]/product")]
        public async Task<IActionResult> GetProductAsync()
        {
            string key = DateTime.Now.Day.ToString() + "product";
            //var data = distributedCache.Get("key");
            await cacheService.SetAsync(key, "selam", TimeSpan.FromSeconds(5));
            cacheService.Get<string>(key);
            await cacheService.RemoveAsync(key);
            return Ok(cacheService.Get<string>(key));
        }
    }
}
