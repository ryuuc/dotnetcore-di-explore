using System;

namespace Explore.DI
{
    public interface ISupportRequiredService
    {
        object GetRequiredService(Type serviceType);
    }
}
