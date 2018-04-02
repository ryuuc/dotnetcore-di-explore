using System;
using System.Reflection;

namespace Explore.DI.ServiceLookup
{
    internal class ConstructorCallSite : IServiceCallSite
    {
        internal ConstructorInfo ConstructorInfo { get; }
        internal IServiceCallSite[] ParameterCallSites { get; }

        public ConstructorCallSite(Type serviceType, ConstructorInfo construtorInfo,IServiceCallSite[] parameterCallSites)
        {
            ServiceType = serviceType;
            ConstructorInfo = construtorInfo;
            ParameterCallSites = parameterCallSites;
            ParameterCallSites = parameterCallSites;
        }

        public Type ServiceType { get; }
        public Type ImplementationType => ConstructorInfo.DeclaringType;
    }
}
