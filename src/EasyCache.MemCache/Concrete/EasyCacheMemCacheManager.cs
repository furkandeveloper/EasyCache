using EasyCache.Core.Abstractions;
using Enyim.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.MemCache.Concrete
{
    /// <summary>
    /// This class includes implementation of Cache operation for MemCache
    /// </summary>
    public class EasyCacheMemCacheManager : IEasyCacheService
    {
        private readonly IMemcachedClient memcachedClient;

        public EasyCacheMemCacheManager(IMemcachedClient memcachedClient)
        {
            this.memcachedClient = memcachedClient;
        }
        public virtual T Get<T>(string key)
        {
            var data = memcachedClient.Get<T>(key);
            if (data == null) return default(T);
            else return data;
        }

        public virtual async Task<T> GetAsync<T>(string key)
        {
            var data = await memcachedClient.GetValueAsync<T>(key);
            if (data == null)
                return default(T);
            else
                return data;
        }

        public virtual void Remove<T>(string key)
        {
            memcachedClient.Remove(key);
        }

        public virtual async Task RemoveAsync<T>(string key)
        {
            await memcachedClient.RemoveAsync(key);
        }

        public virtual void Set<T>(string key, T value, TimeSpan expireTime)
        {
            memcachedClient.Set(key, value, (int)expireTime.TotalSeconds);
        }

        public virtual async Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            await memcachedClient.SetAsync(key, value, (int)expireTime.TotalSeconds);
        }
    }
}
