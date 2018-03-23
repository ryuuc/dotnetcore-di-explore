namespace Explore.DI
{
    /// <summary>
    /// 服务生命周期
    /// </summary>
    public enum ServiceLifetime
    {
        /// <summary>
        /// 单例
        /// 服务在第一次被请求时创建，后续请求使用同一实例
        /// </summary>
        Singleton,

        /// <summary>
        /// 作用域(TBD)
        /// Specifies that a new instance of the service will be created for each scope.
        /// <remarks>
        /// In ASP.NET Core applications a scope is created around each server request.
        /// </remarks>
        /// </summary>
        Scoped,

        /// <summary>
        /// 瞬态
        /// 服务在每次请求时都会创建（every time it is requested），
        /// 适合轻量级（lightweight）、无状态（stateless）的服务。
        /// </summary>
        Transient
    }
}
