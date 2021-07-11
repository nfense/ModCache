using System.Net;
using NProxy.Modules;
using NProxy.Nodes;

namespace Nfense.ModCache {
    internal class ModInit : Module {
        private CacheManager cache;

        ModInit () {
            this.cache = new CacheManager();
        }

        public override bool OnStartRequest(HttpListenerContext ctx, Node node)
        {
            string hostname = ctx.Request.Url.Host;
            string path = ctx.Request.Url.PathAndQuery;

            CachedResource resource = this.cache.GetResource(hostname, path);
            if (resource != null)
            {
                ctx.Response.Headers.Add("Content-Type", resource.ContentType);
                ctx.Response.Headers.Add("X-Cached-By", "NCache");
                ctx.Response.OutputStream.Write(resource.Buffer, 0, resource.Buffer.Length);
                ctx.Response.Close();
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool OnEndRequest(HttpListenerContext ctx, Node node, byte[] response)
        {
            if (!node.cache.enable) {
                return true;
            }

            string hostname = ctx.Request.Url.Host;
            string path = ctx.Request.Url.PathAndQuery;
            string contentType = ctx.Response.ContentType;

            if (ctx.Response.ContentType != null)
            {
                this.cache.AddResource(hostname, path, new CachedResource(ctx.Response.ContentType, response));
            }

            return true;
        }

        public override string GetName()
        {
            return "ModCache";
        }
    }
}