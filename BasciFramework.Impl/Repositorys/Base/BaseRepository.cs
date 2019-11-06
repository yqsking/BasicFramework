using BasicFramework.Dommain.Entitys;
using BasicFramework.Dommain.Repositorys;
using BasicFramework.Dommain.Repositorys.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BasicFramework.Impl.Repositorys
{
    /// <summary>
    /// 基础仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> :ReadOnlyBaseRepository<TEntity>, IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// 仓储工作单元
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(IUnitOfWork unitOfWork) :base(unitOfWork.GetDbContext())
        {
            _unitOfWork = unitOfWork;
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
            await _dbContext.Set<TEntity>().AddRangeAsync(entitys);
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
            return await Task.FromResult(true);
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
            return await Task.FromResult(true);
        }

       
    }
}
