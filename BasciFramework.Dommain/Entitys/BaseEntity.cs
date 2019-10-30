using System;
using System.ComponentModel.DataAnnotations;

namespace BasciFramework.Dommain.Entitys
{
    /// <summary>
    /// 实体模型基类
    /// </summary>
    [Serializable]
    public class BaseEntity
    {

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString("N");
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 唯一id
        /// </summary>
        [Key]
        public string Id { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }
    }
}
