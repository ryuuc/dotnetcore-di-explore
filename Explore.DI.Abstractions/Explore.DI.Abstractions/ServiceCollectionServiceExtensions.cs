﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explore.DI.Abstractions
{
    public static class ServiceCollectionServiceExtensions
    {
        private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }

        private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationFactory, lifetime);
            collection.Add(descriptor);
            return collection;
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
        public static IServiceCollection AddTransient(this IServiceCollection collection, Type serviceType, Type implementationType)
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

            return Add(collection, serviceType, implementationType, ServiceLifetime.Transient);
        }

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

        public static void TryAddTransient<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            TryAddTransient(collection, typeof(TService), typeof(TImplementation));
        }

        public static void TryAddTransient<TService>(this IServiceCollection collection, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Transient(implementationFactory));
        }
        #endregion

        #region scoped
        public static IServiceCollection AddScoped(this IServiceCollection collection, Type serviceType, Type implementationType)
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

            return Add(collection, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddScoped(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return Add(collection, serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            return collection.AddScoped(typeof(TService), typeof(TImplementation));
        }

        public static IServiceCollection AddScoped(this IServiceCollection collection, Type serviceType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            return collection.AddScoped(serviceType, serviceType);
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection collection)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return collection.AddScoped(typeof(TService));
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection collection, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return collection.AddScoped(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection collection, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }
            return collection.AddScoped(typeof(TService), implementationFactory);
        }
        #endregion

        #region Singleton
        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, Type implementationType)
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
            return Add(collection, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
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
            return Add(collection, serviceType, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return collection.AddSingleton(typeof(TService), typeof(TimeoutException));
        }

        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            return collection.AddSingleton(serviceType, serviceType);
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return collection.AddSingleton(typeof(TService));
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return collection.AddSingleton(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection collection, Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }
            return collection.AddSingleton(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }

            var serviceDescriptor = new ServiceDescriptor(serviceType, implementationInstance);
            collection.Add(serviceDescriptor);
            return collection;
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection,TService implementationInstance)
            where TService : class
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if(implementationInstance == null)
            {
                throw new ArgumentNullException(nameof(implementationInstance));
            }
            return collection.AddSingleton(typeof(TService), implementationInstance);
        }
        #endregion
              
    }
}
