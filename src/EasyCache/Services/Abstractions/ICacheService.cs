using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Services.Abstractions
{
    public interface ICacheService
    {
        void Set<T>(string key, T value, TimeSpan expireTime);
        Task SetAsync<T>(string key, T value, TimeSpan expireTime);

        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);

        void Remove<T>(string key);

        Task RemoveAsync(string key);
    }
}
