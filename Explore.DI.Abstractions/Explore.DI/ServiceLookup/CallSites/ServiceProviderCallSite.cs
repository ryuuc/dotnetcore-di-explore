using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.DI.ServiceLookup
{
    internal class ServiceProviderCallSite : IServiceCallSite
    {
        public Type ServiceType { get; } = typeof(IServiceProvider);
        public Type ImplementationType { get; } = typeof(ServiceProvider);
    }
}
