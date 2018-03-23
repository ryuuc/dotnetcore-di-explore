using System;

namespace Explore.DI
{
    public delegate object ObjectFactory(IServiceProvider serviceProvider, object[] arguments);
}
