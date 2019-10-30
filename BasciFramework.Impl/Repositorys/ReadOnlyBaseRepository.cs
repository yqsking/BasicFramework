using BasciFramework.Dommain.Entitys;
using BasciFramework.Dommain.Repositorys;
using BasicFramework.Common.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasciFramework.Impl.Repositorys
{

    /// <summary>
    /// 基础只读仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ReadOnlyBaseRepository<TEntity> : IReadOnlyBaseRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ReadOnlyBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
           return await  _dbContext.Set<TEntity>().AsNoTracking().CountAsync(expression);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await _dbContext.Set<TEntity>().AsNoTracking().CountAsync(expression)) > 0;
        }

        /// <summary>
        /// 根据主键查询单个实体模型
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async  Task<TEntity> GetByKeyAsync(string key)
        {
            return await  _dbContext.Set<TEntity>().FindAsync(key);
        }

        /// <summary>
        /// 根据条件查询单个实体模型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async  Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public Task<IList<TEntity>> GetEntityAllListAsync(Expression<Func<TEntity, bool>> conditionExpression, Expression<Func<TEntity, dynamic>> groupbyExpression, bool isDesc = true)
        {
            throw new NotImplementedException();
        }


        public Task<PageResult<TEntity>> GetEntityPageList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> conditionExpression = null, Expression<Func<TEntity, dynamic>> groupbyExpression = null, bool isDesc = true)
        {
            throw new NotImplementedException();
        }
    }
}
