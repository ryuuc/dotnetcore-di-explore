using System;

namespace Explore.DI
{
    public interface IServiceProviderFactory<TContainerBuilder>
    {
        TContainerBuilder CreateBuilder(IServiceCollection services);

        IServiceProvider CreateServiceProvider(TContainerBuilder containerBuilder);
    }
}
