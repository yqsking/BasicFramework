using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicFramework.Dommain.Entitys.User
{
    /// <summary>
    /// 权限信息
    /// </summary>
    [Table("t_Table_Root")]
    public  class RootEntity:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootName">权限名</param>
        /// <param name="rootCode">权限代码</param>
        /// <param name="remark">备注</param>
        public RootEntity(string rootName,string rootCode,string remark)
        {
            RootName = rootName;
            RootCode = rootCode;
            Remark = remark;
        }
        /// <summary>
        /// 权限名
        /// </summary>
        [MaxLength(50),Required]
        public string RootName { get; private set; }
        /// <summary>
        /// 权限代码
        /// </summary>
        [MaxLength(50),Required]
        public string RootCode { get; private set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; private set; }
    }
}
