using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explore.DI.Abstractions
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        private static IServiceCollection Add(IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            services.Add(descriptor);
            return services;
        }

        public static void TryAdd(this IServiceCollection collection, ServiceDescriptor descriptor)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (descriptor == null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            if (!collection.Any(d => d.ServiceType == descriptor.ServiceType))
            {
                collection.Add(descriptor);
            }
        }

        public static void TryAdd(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (descriptors == null)
            {
                throw new ArgumentNullException(nameof(descriptors));
            }

            foreach (var d in descriptors)
            {
                collection.TryAdd(d);
            }
        }

        #region transient
        public static void TryAddTransient(this IServiceCollection collection, Type serviceType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var descriptor = ServiceDescriptor.Transient(serviceType, serviceType);

            TryAdd(collection, descriptor);
        }

        public static void TryAddTransient(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            var descriptor = ServiceDescriptor.Transient(serviceType, implementationType);

            TryAdd(collection, descriptor);
        }

        public static void TryAddTransient(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            var descriptor = ServiceDescriptor.Transient(serviceType, implementationFactory);
            TryAdd(collection, descriptor);
        }

        public static void TryAddTransient<TService>(this IServiceCollection collection)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            TryAddTransient(collection, typeof(TService), typeof(TService));
        }

        public static void TryAddTransient<TService,TImplementation>(this IServiceCollection collection)
            where TService:class
            where TImplementation : class, TService
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            TryAddTransient(collection, typeof(TService), typeof(TImplementation));
        }

        public static void TryAddTransient<TService>(this IServiceCollection collection,Func<IServiceProvider,TService> implementationFactory)
            where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Transient(implementationFactory));
        }
        #endregion
    }
}
