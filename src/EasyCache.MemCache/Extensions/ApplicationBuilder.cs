using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.MemCache.Extensions
{
    /// <summary>
    /// This class includes extension method for Memcache.
    /// </summary>
    public static class ApplicationBuilder
    {
        /// <summary>
        /// Apply EasyMemCache
        /// </summary>
        /// <param name="app">
        /// Microsoft.AspNetCore.Builder.IApplicationBuilder
        /// </param>
        /// <returns>
        /// Microsoft.AspNetCore.Builder.IApplicationBuilder
        /// </returns>
        public static IApplicationBuilder ApplyEasyMemCache(this IApplicationBuilder app)
        {
            app.UseEnyimMemcached();
            return app;
        }
    }
}
