using EasyCache.Attributes;
using EasyCache.Sample.Dtos;
using EasyCache.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCache.Helpers.Extensions;

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

        [HttpGet("[controller]/product")]
        [AutoCache(typeof(ProductResponseDto[]),"example")]
        public async Task<IActionResult> GetProductAsync()
        {
            return Ok(cacheService.Get<string>(DateTime.UtcNow.Minute + " product"));
        }

        [HttpGet("[controller]/order")]
        public async Task<IActionResult> GetOrderAsync()
        {
            return Ok(await cacheService.GetAndSetAsync("order", async () => await cacheService.GetAsync<string>("order"), TimeSpan.FromMinutes(10)););
        }
    }
}
