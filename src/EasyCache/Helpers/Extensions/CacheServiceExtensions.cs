using EasyCache.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Helpers.Extensions
{
    public static class CacheServiceExtensions
    {
        public static T GetAndSet<T>(this ICacheService cacheService, string key, Func<T> getResult,TimeSpan expireTime)
        {
            var data = cacheService.Get<T>(key);

            if (data == null)
            {
                data = getResult();
                cacheService.Set(key, data,expireTime);
            }

            return data;
        }

        public static T GetAndSetAsync<T>(this ICacheService cacheService, string key, Func<T> getResult, TimeSpan expireTime)
        {
            var data = cacheService.Get<T>(key);

            if (data == null)
            {
                data = getResult();
                cacheService.Set(key, data, expireTime);
            }

            return data;
        }
    }
}
