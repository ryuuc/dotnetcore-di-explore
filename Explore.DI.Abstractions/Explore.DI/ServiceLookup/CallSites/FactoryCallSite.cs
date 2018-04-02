using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.DI.ServiceLookup
{
    internal class FactoryCallSite : IServiceCallSite
    {
        public Func<IServiceProvider,object> Factory { get; }
        public Type ServiceType { get; }
        public Type ImplementationType => null;
        public FactoryCallSite(Type serviceType,Func<IServiceProvider,object> factory)
        {
            Factory = factory;
            ServiceType = serviceType;
        }
    }
}
