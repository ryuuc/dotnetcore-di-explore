using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.DI.Abstractions
{
    public static class ServiceProviderServiceExtensions
    {
        public static IServiceCollection AddTransient(this IServiceCollection services,Type serviceType,Type implementationType)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if(serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if(implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        private static IServiceCollection Add(IServiceCollection services,Type serviceType,Type implementationType,ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            services.Add(descriptor);
            return services;
        }
    }
}
