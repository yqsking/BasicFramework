using BasicFramework.Dommain.Entitys;
using BasicFramework.Dommain.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BasicFramework.Impl.Repositorys
{
    /// <summary>
    /// 基础仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task<bool> AddEntityAsync(params TEntity[] entitys)
        {
            if(!entitys.Any())
            {
                throw new Exception("实体模型为空");
            }
            await  _dbContext.Set<TEntity>().AddRangeAsync(entitys);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 修改一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEntityAsync(params TEntity[] entitys)
        {
            if (!entitys.Any())
            {
                throw new Exception("实体模型为空");
            }
            _dbContext.Set<TEntity>().UpdateRange(entitys);
            await _dbContext.SaveChangesAsync();
            return true;
        } 

        /// <summary>
        /// 删除一个或者多个实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEntityAsync(params TEntity[] entitys)
        {
            if(!entitys.Any())
            {
                throw new Exception("实体模型为空");
            }
            _dbContext.Set<TEntity>().RemoveRange(entitys);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       
    }
}
