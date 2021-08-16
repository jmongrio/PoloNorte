using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace campanas_publicitarias.Helper
{
    public class API
    {
        public HttpClient ClienteInit()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44378");
            return client;
        }
    }
}
