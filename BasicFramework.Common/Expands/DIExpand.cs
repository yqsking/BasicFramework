using BasicFramework.Appliction.Queries;
using BasicFramework.Appliction.Queries.Impl;
using BasicFramework.Dommain.Repositorys;
using BasicFramework.Dommain.Repositorys.Base;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 依赖注入拓展
    /// </summary>
    public static class DIExpand
    {
       /// <summary>
       /// 依赖注入查询器
       /// </summary>
       /// <param name="collection"></param>
        public static void RegisterQueries(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IUserQueries),typeof(UserQueries));
        }

        /// <summary>
        /// 依赖注入仓储
        /// </summary>
        /// <param name="collection"></param>
        public static void RegisterRepositorys(this IServiceCollection collection)
        {
        }


    }
}
