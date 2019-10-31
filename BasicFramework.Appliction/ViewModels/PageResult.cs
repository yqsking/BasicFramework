using System.Collections.Generic;

namespace BasicFramework.Appliction.ViewModels
{
    /// <summary>
    /// 通用分页查询返回结果
    /// </summary>
    /// <typeparam name="ResponseDto"></typeparam>
    public class PageResult<ResponseDto> :ApiResult where ResponseDto:BaseResponseDto
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
        public List<ResponseDto> Data { get; set; }
    }
}
