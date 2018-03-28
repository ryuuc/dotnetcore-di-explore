using System;

namespace Explore.DI.ServiceLookup
{
    internal interface IServiceCallSite
    {
        Type ServiceType { get; }
        Type ImplementationType { get; }
    }
}
