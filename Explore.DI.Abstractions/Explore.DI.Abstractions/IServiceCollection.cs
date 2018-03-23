using System.Collections.Generic;

namespace Explore.DI
{
    /// <summary>
    /// 指定服务描述器集合的契约
    /// </summary>
    public interface IServiceCollection : IList<ServiceDescriptor>
    {
    }
}
