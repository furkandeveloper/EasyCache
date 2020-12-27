using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyCache.Core.Abstractions
{
    /// <summary>
    /// This interface base methods for Cache
    /// </summary>
    public interface IEasyCacheService
    {
        /// <summary>
        /// Set Cache
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        /// <param name="value">
        /// Object to be cached
        /// </param>
        /// <param name="expireTime">
        /// Cache Expire time
        /// </param>
        void Set<T>(string key, T value, TimeSpan expireTime);
        /// <summary>
        /// Set cache async version
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        /// <param name="value">
        /// Object to be cached
        /// </param>
        /// <param name="expireTime">
        /// Cache Expire time</param>
        /// <returns>
        /// System.Threading.Tasks.Task
        /// </returns>
        Task SetAsync<T>(string key, T value, TimeSpan expireTime);

        /// <summary>
        /// Get cached object
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        /// <returns>
        /// Object to be cached
        /// </returns>
        T Get<T>(string key);

        /// <summary>
        /// Get cached object async version
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        /// <returns>
        /// Object to be cached
        /// </returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Remove cache
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        void Remove<T>(string key);

        /// <summary>
        /// Remove cache
        /// </summary>
        /// <typeparam name="T">
        /// Object to be cached
        /// </typeparam>
        /// <param name="key">
        /// Uniqe cache key
        /// </param>
        Task RemoveAsync<T>(string key);
    }
}
