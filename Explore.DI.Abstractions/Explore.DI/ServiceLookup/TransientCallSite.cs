using System;

namespace Explore.DI.ServiceLookup
{
    internal class TransientCallSite : IServiceCallSite
    {
        internal IServiceCallSite ServiceCallSite { get; }
        public TransientCallSite(IServiceCallSite serviceCallSite)
        {
            ServiceCallSite = serviceCallSite;
        }

        public Type ServiceType => ServiceCallSite.ServiceType;
        public Type ImplementationType => ServiceCallSite.ImplementationType;
    }
}
