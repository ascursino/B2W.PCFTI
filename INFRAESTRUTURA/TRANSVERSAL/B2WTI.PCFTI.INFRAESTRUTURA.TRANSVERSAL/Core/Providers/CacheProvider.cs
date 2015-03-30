
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers
{
    using System;
    using System.Runtime.Caching;
    using System.Runtime.Serialization;

    public class CacheProvider
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(cacheTime);

            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Set(string key, object data)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = System.Runtime.Caching.MemoryCache.InfiniteAbsoluteExpiration;

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }
    }
}
