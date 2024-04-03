using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching.Abstract
{
    public interface ICacheProvider
    {
        bool Any(string key);
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expiration);
        bool Remove(string key);
    }
}
