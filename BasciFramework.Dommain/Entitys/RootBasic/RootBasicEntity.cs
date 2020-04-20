using BasicFramework.Dommain.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.RootBasic
{
    /// <summary>
    /// 权限基础信息
    /// </summary>
    [Table("t_user_rootBasic")]
    public class RootBasicEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootName">权限名</param>
        /// <param name="rootCode">权限代码</param>
        /// <param name="remark">备注</param>
        public RootBasicEntity(string rootName, string rootCode, string remark)
        {
            this.Name = rootName;
            this.Code = rootCode;
            this.Remark = remark;
        }
        /// <summary>
        /// 权限名
        /// </summary>
        [MaxLength(50), Required]
        public string Name { get; private set; }

        /// <summary>
        /// 权限代码
        /// </summary>
        [MaxLength(50), Required]
        public string Code { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; private set; }

        /// <summary>
        /// 设置权限基础信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="remark"></param>
        public void SetRootBasicInfo(string name, string code, string remark)
        {
            this.Name = name;
            this.Code = code;
            this.Remark = remark;
        }


    }
}
