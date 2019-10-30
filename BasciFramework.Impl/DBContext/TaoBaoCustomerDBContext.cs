using BasciFramework.Dommain.Entitys.User;
using Microsoft.EntityFrameworkCore;

namespace BasciFramework.Impl.DBContext
{
    /// <summary>
    /// 数据库上下文对象
    /// </summary>
    public  class TaoBaoCustomerDBContext:DbContext
    {
     
        public TaoBaoCustomerDBContext(DbContextOptions<TaoBaoCustomerDBContext> dbContextOptions) :base(dbContextOptions)
        {

        }

        /// <summary>
        /// 用户基础信息
        /// </summary>
        public DbSet<UserEntity> UserEntitys { get; set; }
        /// <summary>
        /// 角色信息
        /// </summary>
        public DbSet<RoleEntity> RoleEntitys { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public DbSet<UserRoleEntity> UserRoleEntitys { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public DbSet<RoleRootEntity> RoleRootEntity { get; set; }
    }
}
