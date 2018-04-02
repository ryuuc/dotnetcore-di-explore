using System;
using System.Collections.Generic;

namespace Explore.DI.ServiceLookup
{
    internal class IEnumerableCallSite:IServiceCallSite
    {
        internal Type ItemType { get; }
        internal IServiceCallSite[] ServiceCallSites { get; }

        public IEnumerableCallSite(Type itemType,IServiceCallSite[] serviceCallSites)
        {
            ItemType = itemType;
            ServiceCallSites = serviceCallSites;
        }

        public Type ServiceType => typeof(IEnumerable<>).MakeGenericType(ItemType);
        public Type ImplementationType => ItemType.MakeGenericType();
    }
}
