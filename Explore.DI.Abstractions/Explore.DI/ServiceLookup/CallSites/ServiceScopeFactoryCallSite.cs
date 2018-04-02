using System;
using System.Collections.Generic;
using System.Text;
using Explore.DI.Abstractions;

namespace Explore.DI.ServiceLookup
{
    internal class ServiceScopeFactoryCallSite : IServiceCallSite
    {
        public Type ServiceType { get; } = typeof(IServiceScopeFactory);
        public Type ImplementationType { get; } = typeof(ServiceProviderEngine);
    }
}
