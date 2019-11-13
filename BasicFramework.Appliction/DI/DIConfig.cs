using BasicFramework.Appliction.Queries;
using BasicFramework.Appliction.Queries.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 依赖注入服务
    /// </summary>
    public static class DIConfig
    {
        /// <summary>
        /// 依赖注入公用服务
        /// </summary>
        /// <param name="collection"></param>
        public static void RegisterCommon(this IServiceCollection collection)
        {

        }


        /// <summary>
        /// 依赖注入查询器
        /// </summary>
        /// <param name="collection"></param>
        public static void RegisterQueries(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IUserQueries), typeof(UserQueries));
        }

        /// <summary>
        /// 依赖注入仓储
        /// </summary>
        /// <param name="collection"></param>
        public static void RegisterRepository(this IServiceCollection collection)
        {

        }
    }
}
