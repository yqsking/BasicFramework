using BasicFramework.Dommain.Repositorys.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace BasicFramework.Impl.Repositorys.Base
{
    /// <summary>
    /// 仓储工作单元
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        public   DbContext dbContext { get; }

        /// <summary>
        /// 单元事务
        /// </summary>
        public IDbContextTransaction dbContextTransaction { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public UnitOfWork(DbContext db)
        {
            dbContext = db;
            dbContextTransaction = dbContext.Database.BeginTransaction();
        }


        /// <summary>
        /// 提交当前工作单元事务
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await dbContextTransaction.CommitAsync();
            await dbContextTransaction.DisposeAsync();
        }

        /// <summary>
        /// 回滚当前工作单元事务
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            await dbContextTransaction.RollbackAsync();
            await dbContextTransaction.DisposeAsync();
        }
    }
}
