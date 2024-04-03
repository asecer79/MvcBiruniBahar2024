using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Concrete
{
    public class MemoryCacheProvider(IMemoryCache memoryCache) : ICacheProvider
    {
        private IMemoryCache _memoryCache = memoryCache;


        public bool Any(string key)
        {
            return _memoryCache.Get(key) == null ? false : true;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            _memoryCache.Set<T>(key, value, expiration);
        }

        public bool Remove(string key)
        {
            memoryCache.Remove(key);
            return true;
        }
    }
}
