using System;

namespace Explore.DI.ServiceLookup
{
    internal interface IServiceProviderEngine:IDisposable,IServiceProvider
    {
        IServiceScope RootScope { get; }
    }
}
