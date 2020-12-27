using EasyCache.Core.Abstractions;
using EasyCache.Memory.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Memory.Extensions
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
        public static IServiceCollection AddEasyMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddTransient<IEasyCacheService, EasyMemoryCacheManager>();
            return services;
        }
    }
}
