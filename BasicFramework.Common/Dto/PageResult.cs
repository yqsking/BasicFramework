using System;
using System.Collections.Generic;
using System.Text;

namespace BasicFramework.Common.Dto
{
    /// <summary>
    /// 通用分页查询返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class PageResult<T> :ApiResult where T:new ()
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPageIndex { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalNumber { get; set; }
        /// <summary>
        /// 查询数据
        /// </summary>
        public IList<T> Data { get; set; }
    }
}
