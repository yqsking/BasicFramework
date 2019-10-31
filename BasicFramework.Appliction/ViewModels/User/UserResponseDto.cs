namespace BasicFramework.Appliction.ViewModels.User
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    public class UserResponseDto:BaseResponseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get;  set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get;  set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd { get;  set; }

       
    }
}
