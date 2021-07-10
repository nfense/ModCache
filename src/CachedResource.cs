namespace ModCache
{
    public class CachedResource
    {
        private string contentType;
        private byte[] buffer;

        public CachedResource(string contentType, byte[] buffer)
        {
            this.contentType = contentType;
            this.buffer = buffer;
        }

        public byte[] Buffer
        {
            get
            {
                return this.buffer;
            }
        }

        public string ContentType
        {
            get
            {
                return this.contentType;
            }
        }
    }
}