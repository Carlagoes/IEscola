﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IEscola.Api.PollyPolices
{
    public class PolicyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Policies.PolicyStrategy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
        }
    }
}
