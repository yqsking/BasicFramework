namespace BasicFramework.Common.Dto
{
    /// <summary>
    /// 通用api请求结果
    /// </summary>
    public  class ApiResult
    {
        /// <summary>
        /// 请求状态
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }
    }
}
