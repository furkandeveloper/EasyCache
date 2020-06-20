using EasyCache.Services.Abstractions;
using Enyim.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Services.Concrete
{
    /// <summary>
    /// Memcached implementation for easy cache
    /// </summary>
    public class MemcachedManager : ICacheService
    {
        private readonly IMemcachedClient memcachedClient;

        public MemcachedManager(IMemcachedClient memcachedClient)
        {
            this.memcachedClient = memcachedClient;
        }
        public T Get<T>(string key)
        {
            var data = memcachedClient.Get<T>(key);
            if (data == null) return default(T);
            else return data;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var data = await memcachedClient.GetValueAsync<T>(key);
            if (data == null)
                return default(T);
            else
                return data;
        }

        public void Remove<T>(string key)
        {
            memcachedClient.Remove(key);
        }

        public async Task RemoveAsync(string key)
        {
            await memcachedClient.RemoveAsync(key);
        }

        public void Set<T>(string key, T value, TimeSpan expireTime)
        {
            memcachedClient.Set(key, value, (int)expireTime.TotalSeconds);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            await memcachedClient.SetAsync(key, value, (int)expireTime.TotalSeconds);
        }
    }
}
