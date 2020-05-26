using EasyCache.Services.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Services.Concrete
{
    public class MemoryCacheManager : ICacheService
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public T Get<T>(string key)
        {
            var data = memoryCache.Get<T>(key);
            if (data == null) return default(T);
            return data;
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotSupportedException(nameof(IMemoryCache));
        }

        public void Remove<T>(string key)
        {
            memoryCache.Remove(key);
        }

        public Task RemoveAsync(string key)
        {
            throw new NotSupportedException(nameof(IMemoryCache));
        }

        public void Set<T>(string key, T value,TimeSpan expireTime)
        {
            memoryCache.Set(key, value, expireTime);
        }

        public Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            throw new NotSupportedException(nameof(IMemoryCache));
        }
    }
}
