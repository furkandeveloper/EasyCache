using EasyCache.Core.Abstractions;
using EasyCache.Sample.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EasyCache.Core.Extensions;
using EasyCache.AspNetCore.Attributes;

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

        /// <summary>
        /// Get product from cache
        /// </summary>
        /// <returns></returns>
        [HttpGet("[controller]/product")]
        [AutoCache(typeof(ProductResponseDto[]), "products")]
        public IActionResult AutoCache()
        {
            return Ok(new List<ProductResponseDto>
            {
                new ProductResponseDto
                {
                    Name = "Product 1",
                    Description = "Product Description 1"
                },
                new ProductResponseDto
                {
                    Name = "Product 2",
                    Description = "Product Description 2"
                },
                new ProductResponseDto
                {
                    Name = "Product 3",
                    Description = "Product Description 3"
                }
            });
        }

        [HttpGet("[controller]/order")]
        public IActionResult Order()
        {
            easyCacheService.GetAndSet("getAndSet", () => AutoCache(), TimeSpan.FromSeconds(1));
            return NoContent();
        }

        [HttpGet("[controller]/category")]
        public async Task<IActionResult> CategoryAsync()
        {
            var data = await easyCacheService.GetAndSet("getAndSet", () => GetData(), TimeSpan.FromSeconds(1));
            return Ok(data);
        }

        [NonAction]
        public async Task<string[]> GetData()
        {
            return new string[] {
                "Data"
            };
        }
    }
}
