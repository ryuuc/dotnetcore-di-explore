using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Explore.DI.Abstractions.ServiceCollectionDescriptorExtensions
{
    public static class ServiceCollectionDescriptorExtensions
    {
        public static IServiceCollection Add(this IServiceCollection collection, ServiceDescriptor descriptor)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (descriptor == null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            collection.Add(descriptor);
            return collection;
        }

        public static IServiceCollection Add(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (descriptors == null)
            {
                throw new ArgumentNullException(nameof(descriptors));
            }

            foreach (var descriptor in descriptors)
            {
                collection.Add(descriptors);
            }

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

        #region Transient start

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

            var desciptor = ServiceDescriptor.Transient(serviceType, serviceType);
            TryAdd(collection, desciptor);
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

        public static void TryAddTransient<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory)
            where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Transient(implementationFactory));
        }
        #endregion end

        #region Scoped start
        public static void TryAddScoped<TService>(this IServiceCollection collection, Type serviceType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }
            var descriptor = ServiceDescriptor.Scoped(serviceType, serviceType);
            TryAdd(collection, descriptor);
        }

        public static void TryAddScoped(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            var descriptor = ServiceDescriptor.Scoped(serviceType, implementationType);
            TryAdd(collection, descriptor);
        }
        public static void TryAddScoped(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
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

            var descriptor = ServiceDescriptor.Scoped(serviceType, implementationFactory);
            TryAdd(collection, descriptor);
        }

        public static void TryAddScoped<TService>(this IServiceCollection collection)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            TryAddScoped(collection, typeof(TService), typeof(TService));
        }

        public static void TryAddScoped<TService, TImplementation>(this IServiceCollection collection)
          where TService : class
          where TImplementation : class, TService
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            TryAddScoped(collection, typeof(TService), typeof(TImplementation));
        }

        public static void TryAddScoped<TService>(this IServiceCollection collection, Func<IServiceProvider, TService> implementationFactory)
         where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Scoped(implementationFactory));
        }

        #endregion Scoped end

        #region Singleton start
        public static void TryAddSingleton(this IServiceCollection collection, Type serviceType)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var descriptor = ServiceDescriptor.Singleton(serviceType, serviceType);
            TryAdd(collection, descriptor);
        }
        public static void TryAddSingleton(this IServiceCollection collection,Type serviceType,Type implementationType)
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

            var descriptor = ServiceDescriptor.Singleton(serviceType, implementationType);
            TryAdd(collection, descriptor);
        }

        public static void TryAddSingleton<TService>(this IServiceCollection collection)
            where TService : class
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            TryAddSingleton(collection, typeof(TService), typeof(TService));
        }

        public static void TryAddSingleton<TService>(this IServiceCollection collection,TService serviceType)
            where TService : class
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if(serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var descriptor = ServiceDescriptor.Singleton(typeof(TService), serviceType);
            TryAdd(collection, descriptor);
        }

        public static void TryAddSingleton<TService>(this IServiceCollection collection,Func<IServiceCollection,TService> implementationFactory)
            where TService : class
        {
            collection.TryAdd(ServiceDescriptor.Singleton(implementationFactory));
        }

        public static void TryAddEnumerable(this IServiceCollection collection,ServiceDescriptor descriptor)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if(descriptor == null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }
            var implementationType = descriptor.GetImplementationType();
            if(implementationType ==typeof(object) || implementationType == descriptor.ServiceType)
            {
                throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.TryAddIndistinguishableTypeToEnumerable, implementationType, descriptor.ServiceType));
            }

            if(!collection.Any(d=>d.ServiceType == descriptor.ServiceType && d.GetImplementationType() == implementationType))
            {
                collection.Add(descriptor);
            }
        }

        public static void TryAddEnumerable(this IServiceCollection collection,IEnumerable<ServiceDescriptor> descriptors)
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
                collection.TryAddEnumerable(d);
            }
        }

        public static IServiceCollection Replace(this IServiceCollection collection,ServiceDescriptor descriptor)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (descriptor == null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            var registeredServiceDescriptor = collection.FirstOrDefault(s => s.ServiceType == descriptor.ServiceType);
            if (registeredServiceDescriptor != null)
            {
                collection.Remove(registeredServiceDescriptor);
            }

            collection.Add(descriptor);
            return collection;
        }

        public static IServiceCollection RemoveAll<T>(this IServiceCollection collection)
        {
            return RemoveAll(collection, typeof(T));
        }

        public static IServiceCollection RemoveAll(this IServiceCollection collection, Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            for (var i = collection.Count - 1; i >= 0; i--)
            {
                var descriptor = collection[i];
                if (descriptor.ServiceType == serviceType)
                {
                    collection.RemoveAt(i);
                }
            }

            return collection;
        }

        #endregion Singeton end

    }
}
