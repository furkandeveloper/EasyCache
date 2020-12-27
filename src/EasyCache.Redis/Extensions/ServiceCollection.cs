using EasyCache.Core.Abstractions;
using EasyCache.Redis.Concrete;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Redis.Extensions
{
    /// <summary>
    /// This class includes extension of ServiceCollection
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Add EasyMemoryCache to DI container.
        /// </summary>
        /// <param name="services">
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </param>
        /// <returns>
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </returns>
        public static IServiceCollection AddEasyRedisCache(this IServiceCollection services, Action<RedisCacheOptions> settings)
        {
            services.AddStackExchangeRedisCache(settings);
            services.AddTransient<IEasyCacheService, EasyCacheRedisManager>();
            return services;
        }
    }
}
