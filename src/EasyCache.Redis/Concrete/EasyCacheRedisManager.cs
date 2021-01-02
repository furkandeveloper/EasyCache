using EasyCache.Core.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Redis.Concrete
{
    /// <summary>
    /// This class includes implementation of Cache operation for Redis
    /// </summary>
    public class EasyCacheRedisManager : IEasyCacheService
    {
        private readonly IDistributedCache distributedCache;

        public EasyCacheRedisManager(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public virtual T Get<T>(string key)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                var bytes = distributedCache.Get(key);
                if (bytes is null) return default(T);

                memoryStream.Write(bytes, 0, bytes.Length);

                memoryStream.Seek(0, SeekOrigin.Begin);

                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        public virtual async Task<T> GetAsync<T>(string key)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                var bytes = await distributedCache.GetAsync(key);
                if (bytes is null) return default(T);

                memoryStream.Write(bytes, 0, bytes.Length);

                memoryStream.Seek(0, SeekOrigin.Begin);

                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        public virtual void Remove<T>(string key)
        {
            var data = distributedCache.Get(key);
            if (data != null)
                distributedCache.Remove(key);
        }

        public virtual async Task RemoveAsync<T>(string key)
        {
            var data = await distributedCache.GetAsync(key);
            if (data != null)
                await distributedCache.RemoveAsync(key);
        }

        public virtual void Set<T>(string key, T value, TimeSpan expireTime)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, value);
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(expireTime);
                distributedCache.Set(key, ms.ToArray(), option);
            }
        }

        public virtual async Task SetAsync<T>(string key, T value, TimeSpan expireTime)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, value);
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(expireTime);
                await distributedCache.SetAsync(key, ms.ToArray(), option);
            }
        }
    }
}
