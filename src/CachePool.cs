using System.Collections.Generic;

namespace ModCache
{
    public class CachePool
    {
        private Dictionary<string, CachedResource> pool;

        public CachePool()
        {
            this.pool = new Dictionary<string, CachedResource>();
        }

        public void Add(string path, CachedResource resource)
        {
            this.pool.Add(path, resource);
        }

        public CachedResource Get(string path)
        {
            if (this.pool.ContainsKey(path))
                return this.pool[path];
            else
                return null;
        }
    }
}