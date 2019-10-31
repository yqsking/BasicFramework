using BasciFramework.Dommain.Entitys;
using BasciFramework.Dommain.Repositorys;
using BasicFramework.Dommain.Common.Results;
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

        /// <summary>
        /// 根据条件查询所有实体模型
        /// </summary>
        /// <param name="conditionExpression">条件表达式</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns></returns>
        public async  Task<IList<TEntity>> GetEntityAllListAsync(Expression<Func<TEntity, bool>> conditionExpression, Expression<Func<TEntity, dynamic>> orderByExpression, bool isDesc = true)
        {
            var list=await  _dbContext.Set<TEntity>().WhereIf(conditionExpression!=null,conditionExpression).OrderBy(orderByExpression,isDesc).ToListAsync();
            return list;
        }

        /// <summary>
        /// 根据条件分页查询实体模型
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="conditionExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public async  Task<PageResult<TEntity>> GetEntityPageList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> conditionExpression , Expression<Func<TEntity, dynamic>> orderByExpression , bool isDesc = true)
        {
            var result = new PageResult<TEntity> { PageIndex=pageIndex,PageSize=pageSize,Data=new List<TEntity>()};
            var query = _dbContext.Set<TEntity>().WhereIf(conditionExpression != null, conditionExpression).OrderBy(orderByExpression, isDesc);
            int totalNumber =await query.CountAsync();
            if(totalNumber>0)
            {
                result.TotalNumber = totalNumber;
                result.TotalPageIndex = totalNumber % pageSize == 0 ? totalNumber / pageSize : totalNumber / pageSize + 1;
                result.Data =await query.ToListAsync();
            }
            return result;
           
        }
    }
}
