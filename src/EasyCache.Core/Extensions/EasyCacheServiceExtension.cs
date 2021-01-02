using EasyCache.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCache.Core.Extensions
{
    /// <summary>
    /// This class includes extensions method of IEasyCacheService
    /// </summary>
    public static class EasyCacheServiceExtension
    {
        public static T GetAndSet<T>(this IEasyCacheService easyCacheService, string key, Func<T> getResult, TimeSpan expireTime)
        {
            var data = easyCacheService.Get<T>(key);
            
            if (data == null)
            {
                data = getResult();
                easyCacheService.Set(key, data, expireTime);
            }

            return data;
        }

        public static T GetAndSetAsync<T>(this IEasyCacheService easyCacheService, string key, Func<T> getResult, TimeSpan expireTime)
        {
            var data = easyCacheService.Get<T>(key);

            if (data == null)
            {
                data = getResult();
                easyCacheService.Set(key, data, expireTime);
            }

            return data;
        }
    }
}
