using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.DI.ServiceLookup
{
    internal class ConstantCallSite : IServiceCallSite
    {
        internal object DefaultValue { get; }
        public ConstantCallSite(Type serviceType,object defaultVaule)
        {
            DefaultValue = defaultVaule;
        }
        public Type ServiceType => DefaultValue.GetType();
        public Type ImplementationType => DefaultValue.GetType();
    }
}
