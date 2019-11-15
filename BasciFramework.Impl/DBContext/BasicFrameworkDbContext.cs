using BasicFramework.Dommain.Entitys.User;
using Microsoft.EntityFrameworkCore;

namespace BasicFramework.Impl.DBContext
{
    /// <summary>
    /// 数据库上下文对象
    /// </summary>
    public  class BasicFrameworkDbContext:DbContext
    {
     
        public BasicFrameworkDbContext(DbContextOptions<BasicFrameworkDbContext> dbContextOptions) :base(dbContextOptions)
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
        /// 权限信息
        /// </summary>
        public DbSet<RootEntity> RootEntitys { get; set; }
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
