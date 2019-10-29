using BasciFramework.Dommain.Entitys;
using BasciFramework.Dommain.Repositorys;
using BasicFramework.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BasciFramework.Impl.Repositorys
{

    /// <summary>
    /// 基础只读仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ReadOnlyBaseRepository<TEntity> : IReadOnlyBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> GetEntityAllListAsync(Expression<Func<TEntity, bool>> conditionExpression, Expression<Func<TEntity, dynamic>> groupbyExpression, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> conditionExpression, Expression<Func<TEntity, dynamic>> groupbyExpression = null, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<TEntity>> GetEntityPageList(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> conditionExpression = null, Expression<Func<TEntity, dynamic>> groupbyExpression = null, bool isDesc = true)
        {
            throw new NotImplementedException();
        }
    }
}
