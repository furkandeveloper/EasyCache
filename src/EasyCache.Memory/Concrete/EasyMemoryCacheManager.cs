using EasyCache.Core.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Memory.Concrete
{
    /// <summary>
    /// This class includes implementation of Cache operation for MemoryCache
    /// </summary>
    public class EasyMemoryCacheManager : IEasyCacheService
    {
        private readonly IMemoryCache memoryCache;

        public EasyMemoryCacheManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        
        public virtual T Get<T>(string key)
        {
            var data = memoryCache.Get<T>(key);
            if (data == null) return default(T);
            return data;
        }

        public virtual Task<T> GetAsync<T>(string key)
        {
            var data = Task.Run(() => Get<T>(key));
            return data;
        }

        public virtual void Remove<T>(string key)
        {
            memoryCache.Remove(key);
        }

        public virtual Task RemoveAsync<T>(string key)
        {
            Task.Run(() => Remove<T>(key));
            return Task.CompletedTask;
        }

        public virtual void Set<T>(string key, T value, TimeSpan expireTime)
        {
            memoryCache.Set(key, value, expireTime);
        }

        public virtual Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            Task.Run(() => Set<T>(key, value, expireTime));
            return Task.CompletedTask;
        }
    }
}
