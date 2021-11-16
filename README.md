<p align="center">
    <img src="https://user-images.githubusercontent.com/47147484/97483794-f2755100-1968-11eb-9d7a-90b1433690ee.png" style="max-width:100%;" height="140"  />
</p>

[![CodeFactor](https://www.codefactor.io/repository/github/furkandeveloper/easycache/badge)](https://www.codefactor.io/repository/github/furkandeveloper/easycache)
![Nuget](https://img.shields.io/nuget/dt/EasyCache.Core?label=EasyCache.Core%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyCache.Core?label=EasyCache.Core)
![Nuget](https://img.shields.io/nuget/dt/EasyCache.Memory?label=EasyCache.Memory%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyCache.Memory?label=EasyCache.Memory)
![Nuget](https://img.shields.io/nuget/dt/EasyCache.Redis?label=EasyCache.Redis%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyCache.Redis?label=EasyCache.Redis)
![Nuget](https://img.shields.io/nuget/dt/EasyCache.MemCache?label=EasyCache.MemCache%20Downloads)
![Nuget](https://img.shields.io/nuget/v/EasyCache.MemCache?label=EasyCache.MemCache)
[![Maintainability](https://api.codeclimate.com/v1/badges/c84fe2700fb04bf913f6/maintainability)](https://codeclimate.com/github/furkandeveloper/EasyCache/maintainability)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# EasyCache

Hi, this library contains more than one cache provider.

Thus, you can easily change the provider in your applications without re-implementation.

## Give a Star 🌟
If you liked the project or if EasyCache helped you, please give a star.

# How to use EasyCache?
EasyCache includes one more than cache provider. Choose any.

## EasyCache for MemoryCache
Install `EasyCache.Memory` from [Nuget Package](https://www.nuget.org/packages/EasyCache.Memory)

Add `services.AddEasyMemoryCache()` in startup.cs

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    services.AddEasyMemoryCache(); <-- Initialize EasyCache for MemoryCache
}
```
after get `IEasCacheService` from dependency injection.

```csharp
private readonly IEasyCacheService easyCacheService;

public DefaultController(IEasyCacheService easyCacheService)
{
    this.easyCacheService = easyCacheService;
}
```

<hr/>

## EasyCache for Redis
Install `EasyCache.Redis` from [Nuget Package](https://www.nuget.org/packages/EasyCache.Redis)

Add `services.AddEasyRedisCache()` in startup.cs

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    services.AddEasyRedisCache(options=>
    {
        options.Configuration = "localhost";
        options.InstanceName = GetType().Assembly.GetName().Name
    }); <-- Initialize EasyCache for Redis
}
```
after get `IEasCacheService` from dependency injection.

```csharp
private readonly IEasyCacheService easyCacheService;

public DefaultController(IEasyCacheService easyCacheService)
{
    this.easyCacheService = easyCacheService;
}
```

<hr/>

## EasyCache for MemCache
Install `EasyCache.MemCache` from [Nuget Package](https://www.nuget.org/packages/EasyCache.MemCache)

Add `services.AddEasyRedisCache()` in startup.cs

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    services.AddEasyMemCache(options=>options.AddServer("localhost",11211)); <-- Initialize EasyCache for MemCache
}
```
after get `IEasCacheService` from dependency injection.

```csharp
private readonly IEasyCacheService easyCacheService;

public DefaultController(IEasyCacheService easyCacheService)
{
    this.easyCacheService = easyCacheService;
}
```

<hr/>

See for more information [Wiki](https://github.com/furkandeveloper/EasyCache/wiki)

## Support

If you are having problems, please let us know by [raising a new issue](https://github.com/furkandeveloper/EasyCache/issues/new/choose).

<hr/>

![Alt](https://repobeats.axiom.co/api/embed/dd389955d475338637f2be8512b227262616c41b.svg "Repobeats analytics image")
