using BasciFramework.Dommain.Entitys;
using BasciFramework.Dommain.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasciFramework.Impl.Repositorys
{
    /// <summary>
    /// 基础仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// 添加一个或者多个实体模型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddEntityAsync(params TEntity[] entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEntityAsync(params TEntity[] entitys)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEntityAsync(params TEntity[] entitys)
        {
            throw new NotImplementedException();
        }

       
    }
}
