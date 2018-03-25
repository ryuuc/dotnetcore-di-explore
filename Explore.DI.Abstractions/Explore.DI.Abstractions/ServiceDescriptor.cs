namespace Explore.DI
{
    /// <summary>
    /// 服务描述器，包含服务类型、服务实例及生命周期等信息
    /// </summary>
    public class ServiceDescriptor
    {
        public System.Type ImplementationType { get; }
        public System.Type ServiceType { get; }
        public ServiceLifetime LifeTime { get; }
        public object ImplementationInstance { get; }
        public System.Func<System.IServiceProvider, object> ImplementationFactory { get; }
        internal System.Type GetImplementationType()
        {
            if (ImplementationType != null)
            {
                return ImplementationType;
            }
            else if (ImplementationInstance != null)
            {
                return ImplementationInstance.GetType();
            }
            else if (ImplementationFactory != null)
            {
                var typeArguments = ImplementationFactory.GetType().GenericTypeArguments;

                System.Diagnostics.Debug.Assert(typeArguments.Length == 2);

                return typeArguments[1];
            }

            System.Diagnostics.Debug.Assert(false, "ImplementationType, ImplementationInstance or ImplementationFactory must be non null");

            return null;
        }

        #region ctor

        /// <summary>
        /// 初始化<see cref="ServiceDescriptor"/>实例
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="lifetime">生命周期</param>
        public ServiceDescriptor(System.Type serviceType, System.Type implementationType, ServiceLifetime lifetime)
            : this(serviceType, lifetime)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            ImplementationType = implementationType ?? throw new System.ArgumentNullException(nameof(implementationType));
        }

        /// <summary>
        ///初始化<see cref="ServiceDescriptor"/>实例 
        /// </summary>
        /// <param name="servicetype">服务类型</param>
        /// <param name="instance">实例</param>
        public ServiceDescriptor(System.Type servicetype, object instance)
            : this(servicetype, ServiceLifetime.Singleton)
        {
            if (servicetype == null)
            {
                throw new System.ArgumentNullException(nameof(servicetype));
            }

            ImplementationInstance = instance ?? throw new System.ArgumentNullException(nameof(instance));
        }

        /// <summary>
        /// 初始化<see cref="ServiceDescriptor"/>实例
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="factory">服务工厂</param>
        /// <param name="lifetime">生命周期</param>
        public ServiceDescriptor(System.Type serviceType, System.Func<System.IServiceProvider, object> factory, ServiceLifetime lifetime)
            : this(serviceType, lifetime)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            ImplementationFactory = factory ?? throw new System.ArgumentNullException(nameof(factory));
        }

        /// <summary>
        /// 初始化<see cref="ServiceDescriptor"/>实例
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="lifetime">生命周期</param>
        public ServiceDescriptor(System.Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;

            LifeTime = lifetime;
        }
        #endregion ctor

        #region Transient
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSerivice"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public static ServiceDescriptor Transient<TSerivice, TImplementation>()
            where TSerivice : class
            where TImplementation : class, TSerivice
        {
            return Descriptor<TSerivice, TImplementation>(ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Transient<TService>(System.Func<System.IServiceProvider, TService> implementationFactory)
           where TService : class
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(typeof(TService), implementationFactory, ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Transient(System.Type serviceType, System.Type implementationType)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new System.ArgumentNullException(nameof(implementationType));
            }

            return Descriptor(serviceType, implementationType, ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Transient<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
        }

        public static ServiceDescriptor Transient(System.Type serviceType, System.Func<System.IServiceProvider, object> implementationFactory)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(serviceType, implementationFactory, ServiceLifetime.Transient);
        }
        #endregion Transient

        #region Scoped
        public static ServiceDescriptor Scoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return Descriptor<TService, TImplementation>(ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Scoped<TService>(System.Func<System.IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }
            return Descriptor(typeof(TService), implementationFactory, ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Scoped(System.Type serviceType, System.Type implementationType)
        {
            return Descriptor(serviceType, implementationType, ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Scoped<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(typeof(TService), implementationFactory, ServiceLifetime.Scoped);
        }

        public static ServiceDescriptor Scoped(System.Type serviceType, System.Func<System.IServiceProvider, object> implementationFactory)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(serviceType, implementationFactory, ServiceLifetime.Scoped);
        }
        #endregion Scoped

        #region Singleton
        public static ServiceDescriptor Singleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return Descriptor<TService, TImplementation>(ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton(System.Type serviceType, System.Type implementationType)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new System.ArgumentNullException(nameof(implementationType));
            }

            return Descriptor(serviceType, implementationType, ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(typeof(TService), implementationFactory, ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton<TService>(System.Func<System.IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(typeof(TService), implementationFactory, ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton(System.Type serviceType, System.Func<System.IServiceProvider, object> implementationFactory)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new System.ArgumentNullException(nameof(implementationFactory));
            }

            return Descriptor(serviceType, implementationFactory, ServiceLifetime.Singleton);
        }

        public static ServiceDescriptor Singleton<TService>(TService implementationInstance)
            where TService : class
        {
            if (implementationInstance == null)
            {
                throw new System.ArgumentNullException(nameof(implementationInstance));
            }

            return Singleton(typeof(TService), implementationInstance);
        }

        public static ServiceDescriptor Singleton(System.Type serviceType, object implementationInstance)
        {
            if (serviceType == null)
            {
                throw new System.ArgumentNullException(nameof(serviceType));
            }

            if (implementationInstance == null)
            {
                throw new System.ArgumentNullException(nameof(implementationInstance));
            }

            return new ServiceDescriptor(serviceType, implementationInstance);
        }
        #endregion Singleton

        #region Descriptor
        private static ServiceDescriptor Descriptor<TService, TImplementation>(ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            return Descriptor(typeof(TService), typeof(TImplementation), lifetime: lifetime);
        }

        public static ServiceDescriptor Descriptor(System.Type serviceType, System.Type implementationType, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationType, lifetime);
        }

        public static ServiceDescriptor Descriptor(System.Type serviceType, System.Func<System.IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
        {
            return new ServiceDescriptor(serviceType, implementationFactory, lifetime);
        }
        #endregion Descriptor
    }
}
