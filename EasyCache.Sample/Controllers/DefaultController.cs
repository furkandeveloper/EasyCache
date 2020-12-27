using EasyCache.Core.Abstractions;
using EasyCache.Sample.Dtos;
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
        private readonly IEasyCacheService easyCacheService;

        public DefaultController(IEasyCacheService easyCacheService)
        {
            this.easyCacheService = easyCacheService;
        }

        [HttpGet("[controller]/product")]
        //[AutoCache(typeof(ProductResponseDto[]),"example")]
        public async Task<IActionResult> GetProductAsync()
        {
            easyCacheService.Set<string>("selam", "naber",TimeSpan.FromMinutes(5));
            await easyCacheService.SetAsync("selam2", "naber2", TimeSpan.FromMinutes(3));

            return Ok(easyCacheService.Get<string>("selam2"));
        }

        [HttpGet("[controller]/order")]
        public async Task<IActionResult> GetOrderAsync()
        {
            //return Ok(await cacheService.GetAndSetAsync("order", async () => await GetProductAsync(), TimeSpan.FromMinutes(10)));
            return NoContent();
        }
    }
}
