namespace Explore.DI.ServiceLookup
{
    internal class SingletonCallSite : ScopedCallSite
    {
        public SingletonCallSite(IServiceCallSite serviceCallSite,object cacheKey) : base(serviceCallSite, cacheKey) { }
    }
}
