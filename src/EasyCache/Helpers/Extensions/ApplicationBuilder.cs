using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Helpers.Extensions
{
    public static class ApplicationBuilder
    {
        public static IApplicationBuilder ApplyEasyMemcache(this IApplicationBuilder app)
        {
            app.UseEnyimMemcached();
            return app;
        }
    }
}
