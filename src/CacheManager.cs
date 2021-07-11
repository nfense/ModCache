using System.Collections.Generic;

namespace Nfense.ModCache
{
    public class CacheManager
    {
        private Dictionary<string, CachePool> pools;
        private List<string> cacheWhitelist;

        public CacheManager()
        {
            this.pools = new Dictionary<string, CachePool>();
            this.cacheWhitelist = new List<string>();

            this.cacheWhitelist.Add("text/css");
            this.cacheWhitelist.Add("text/js");
            this.cacheWhitelist.Add("application/javascript");
            this.cacheWhitelist.Add("image/png");
            this.cacheWhitelist.Add("image/jpg");
            this.cacheWhitelist.Add("image/jpeg");
            this.cacheWhitelist.Add("image/svg+xml");
        }

        public void CreatePool(string hostname)
        {
            this.pools.Add(hostname, new CachePool());
        }

        public CachePool GetPool(string hostname)
        {
            if (this.pools.ContainsKey(hostname))
                return this.pools[hostname];
            else
                return null;
        }

        public void AddResource(string hostname, string path, CachedResource resource)
        {
            if (this.GetPool(hostname) == null)
            {
                this.CreatePool(hostname);
            }

            this.GetPool(hostname).Add(path, resource);
        }

        public CachedResource GetResource(string hostname, string path)
        {
            if (this.GetPool(hostname) != null)
            {
                return this.GetPool(hostname).Get(path);
            }

            return null;
        }

        public bool MustBeCached(string contentType)
        {
            contentType = contentType.Split(";")[0];
            return cacheWhitelist.Contains(contentType);
        }
    }
}