using Caching.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Caching.Concrete
{
    public class RedisCacheProvider:ICacheProvider
    {
        private IDatabase _database = ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(0);

        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var cacheString = _database.StringGet(key);
            var result = JsonConvert.DeserializeObject<T>(cacheString);
            return result;

        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            var result = JsonConvert.SerializeObject(value);
            _database.StringSet(key, result, expiration);
        }

        public bool Remove(string key)
        {
            return _database.KeyDelete(key);
        }
    }
}
