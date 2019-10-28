using System;
using System.ComponentModel.DataAnnotations;

namespace BasciFramework.Dommain.Entitys
{
    /// <summary>
    /// 领域模型基类
    /// </summary>
    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// 唯一id
        /// </summary>
        [Key]
        public string Id => Guid.NewGuid().ToString("N");

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
