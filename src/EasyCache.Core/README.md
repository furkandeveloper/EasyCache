## ✨EasyCache.Core

Welcome EasyCache.Core documentation.

This package includes base methods for EasyCache.

```csharp
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
```

## Extensions


```csharp
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
```

See for more information github repo. [EasyCache](https://github.com/furkandeveloper/EasyCache)