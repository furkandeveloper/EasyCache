using EasyCache.Configuration;
using EasyCache.Services.Abstractions;
using EasyCache.Services.Concrete;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Helpers.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddEasyRedisCache(this IServiceCollection services,Action<RedisCacheOptions> settings)
        {
            services.AddStackExchangeRedisCache(settings);
            services.AddTransient<ICacheService, RedisCacheManager>();
            return services;
        }

        public static IServiceCollection AddEasyMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<ICacheService, MemoryCacheManager>();
            return services;
        }

        public static IServiceCollection AddEasyMemcached(this IServiceCollection services,Action<MemcachedClientOptions> memcachedSettings)
        {
            services.AddEnyimMemcached(memcachedSettings);
            services.AddTransient<ICacheService, MemcachedManager>();
            return services;
        }
    }
}
