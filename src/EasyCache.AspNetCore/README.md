## ✨EasyCache.AspNetCore

Welcome EasyCache.AspNetCore documentation.

This package allows you to use the `[AutoCache]` feature.

## What is AutoCache?

With the AutoCache feature, you can cache endpoints that do not change very often.

For example, you can use the country information for the endpoint you return.

```csharp
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
```

See for more information github repo. [EasyCache](https://github.com/furkandeveloper/EasyCache)