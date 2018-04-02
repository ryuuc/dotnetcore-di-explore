using System;

namespace Explore.DI.ServiceLookup
{
    internal class CreateInstanceCallSite : IServiceCallSite
    {
        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public CreateInstanceCallSite(Type serviceType, Type implementationType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }
    }
}
