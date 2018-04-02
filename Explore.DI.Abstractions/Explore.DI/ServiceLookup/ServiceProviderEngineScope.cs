using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.DI.ServiceLookup
{
    internal class ServiceProviderEngineScope:IServiceScope,IServiceProvider
    {
        internal Action<object> _captureDisposableCallback;
        private List<IDisposable> _disposable = new List<IDisposable>();
        private bool _disposed;

        public ServiceProviderEngine 

        public ServiceProviderEngineScope(ServiceProviderEngine engine)
        {
            Engine = engine;
        }
    }
}
