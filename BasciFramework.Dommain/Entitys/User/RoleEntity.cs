using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.User
{
    /// <summary>
    /// 角色信息
    /// </summary>
    [Table("t_User_Role")]
    public  class RoleEntity:BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(50), Required]
        public string RoleName { get; private set; }

        /// <summary>
        /// 角色代码
        /// </summary>
        [MaxLength(50), Required]
        public string RoleCode { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; private set; }
    }
}
