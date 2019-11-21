using BasicFramework.Dommain.Entitys;
using System.Threading.Tasks;

namespace BasicFramework.Dommain.Repositorys
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    public interface IBaseRepository<TEntity> :IReadOnlyBaseRepository<TEntity> where TEntity:BaseEntity
    {
        /// <summary>
        /// 添加一个或者多个实体模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddEntityAsync(params TEntity[] entity);

        /// <summary>
        /// 修改一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task UpdateEntityAsync(params TEntity[] entitys);

        /// <summary>
        /// 删除一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task DeleteEntityAsync(params TEntity[] entitys);
    }
}
