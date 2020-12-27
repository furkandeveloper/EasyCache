using EasyCache.Core.Abstractions;
using EasyCache.MemCache.Concrete;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.MemCache.Extensions
{
    /// <summary>
    /// This class includes extension of ServiceCollection
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Add EasyMemCache to DI container.
        /// </summary>
        /// <param name="services">
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </param>
        /// <returns>
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection
        /// </returns>
        public static IServiceCollection AddEasyMemCache(this IServiceCollection services, Action<MemcachedClientOptions> memcachedSettings)
        {
            services.AddEnyimMemcached(memcachedSettings);
            services.AddTransient<IEasyCacheService, EasyCacheMemCacheManager>();
            return services;
        }
    }
}
