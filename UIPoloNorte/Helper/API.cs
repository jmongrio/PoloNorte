using System;
using System.Net.Http;

namespace UIPoloNorte.Helper
{
    public class API
    {
        public HttpClient ClienteInit()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44378");
            return client;
        }

        public HttpClient campanas_publicitariasInit()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44373");
            return client;
        }
    }
}
