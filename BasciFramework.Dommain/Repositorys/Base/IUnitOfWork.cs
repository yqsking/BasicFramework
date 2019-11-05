using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace BasicFramework.Dommain.Repositorys.Base
{
    /// <summary>
    /// 仓储工作单元接口(仓储工作单元默认开启事务)
    /// </summary>
    public  interface IUnitOfWork
    {
        DbContext dbContext { get; }

        IDbContextTransaction dbContextTransaction { get;  }

        /// <summary>
        /// 提交当前工作单元事务
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// 回滚当前工作单元事务
        /// </summary>
        /// <returns></returns>

        Task RollbackAsync();

    }
}
