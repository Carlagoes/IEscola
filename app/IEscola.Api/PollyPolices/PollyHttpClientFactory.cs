using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IEscola.Api.PollyPolices
{
    public class PollyHttpClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new PolicyHandler
            {
                InnerHandler = base.CreateMessageHandler()
            };
        }
    }

}
