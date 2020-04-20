using BasicFramework.Dommain.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.RoleBasic
{
    /// <summary>
    /// 角色基础信息
    /// </summary>
    [Table("t_user_roleBasic")]
    public class RoleBasicEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <param name="code">角色代码</param>
        /// <param name="remark">备注</param>
        public RoleBasicEntity(string name, string code, string remark)
        {
            this.Name = name;
            this.Code = code;
            this.Remark = remark;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(50), Required]
        public string Name { get; private set; }


        /// <summary>
        /// 角色代码
        /// </summary>
        [MaxLength(50), Required]
        public string Code { get; private set; }


        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; private set; }

        /// <summary>
        /// 设置角色基础信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="remark"></param>
        public void SetRoleBasicInfo(string name, string code, string remark)
        {
            this.Name = name;
            this.Code = code;
            this.Remark = remark;
        }
    }
}
