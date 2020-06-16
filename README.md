![LogoMakr_4DUduR](https://user-images.githubusercontent.com/47147484/84819453-b0361d80-b020-11ea-9df4-7d1b6d5ae39d.png)

# EasyCache

Hi, this library contains more than one cache provider.

Thus, you can easily change the provider in your applications without re-implementation.

# Getting Started

Install EasyCache from [Nuget package](https://www.nuget.org/packages/EasyCacheDotnetCore).

# Redis Configuration

```csharp
services.AddEasyRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = GetType().Assembly.GetName().Name;
});
```

# Memcached Configuration for ConfigureServices
```csharp
services.AddEasyMemcached(options => options.AddServer("localhost", 11211));
```
for Configure
```csharp
app.ApplyEasyMemcache();
```

# Memory Cache Configuration
```csharp
services.AddEasyMemoryCache();
```

# Usage

```csharp
services.AddEasyMemoryCache();
```
<hr/>

```csharp
  [ApiController]
  public class DefaultController : ControllerBase
  {
   private readonly ICacheService cacheService;

   public DefaultController(ICacheService cacheService)
   {
       this.cacheService = cacheService;
   }

   [HttpGet("[controller]/product")]
   public async Task<IActionResult> GetProductAsync()
   {
     return Ok(cacheService.Get<string>(DateTime.UtcNow.Minute + " product"));
   }
}
```

It is read from the key cache specified by AutoCache Attribute. 
Don't worry, if cache is null, cache will be filled after reading the data.
# Example
```csharp
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
}
```

