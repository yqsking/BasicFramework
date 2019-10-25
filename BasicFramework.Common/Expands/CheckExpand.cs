namespace BasicFramework.Common.Expands
{
    /// <summary>
    /// 参数验证拓展
    /// </summary>
    public static  class CheckExpand
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNull(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
