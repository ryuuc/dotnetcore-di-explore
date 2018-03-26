using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Explore.DI.Abstractions
{
    public static class ServiceProviderServiceExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            return (T)provider.GetService(typeof(T));
        }

        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var requiredServiceSupportingProvider = provider as ISupportRequiredService;
            if (requiredServiceSupportingProvider != null)
            {
                return requiredServiceSupportingProvider.GetRequiredService(serviceType);
            }
            var service = provider.GetService(serviceType);
            if (service == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NoServiceRegistered, serviceType));
            }
            return service;
        }

        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            if(provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            return (T)provider.GetRequiredService(typeof(T));
        }

        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            return provider.GetRequiredService<IEnumerable<T>>();
        }

        public static IEnumerable<object> GetServices(this IServiceProvider provider,Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }

        public static IServiceScope CreateScope(this IServiceProvider provider)
        {
            return provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }
    }
}
