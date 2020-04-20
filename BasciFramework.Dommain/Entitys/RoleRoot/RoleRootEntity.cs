using BasicFramework.Dommain.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.RoleRoot
{
    /// <summary>
    /// 角色权限
    /// </summary>
    [Table("t_user_roleRoot")]
    public  class RoleRootEntity:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="rootId">权限id</param>
        public RoleRootEntity(string roleId,string rootId)
        {
            RoleId = roleId;
            RootId = rootId;
        }

        /// <summary>
        /// 角色id
        /// </summary>
        [MaxLength(32), Required]
        public string RoleId { get;private set; }

        /// <summary>
        /// 权限id
        /// </summary>
        [MaxLength(32), Required]
        public string RootId { get; private set; }
    }
}
