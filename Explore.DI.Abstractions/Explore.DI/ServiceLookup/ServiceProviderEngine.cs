using System;
using System.Collections.Generic;
using System.Text;
using Explore.DI.Abstractions;

namespace Explore.DI.ServiceLookup
{
    internal abstract class ServiceProviderEngine : IServiceProviderEngine, IServiceScopeFactory
    {
        private readonly IServiceProviderEngine _callback;
        private readonly Func<Type,Func<ServiceProviderEngineScope,object>>
    }
}
