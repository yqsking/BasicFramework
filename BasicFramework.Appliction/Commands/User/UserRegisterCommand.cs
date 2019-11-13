using BasicFramework.Appliction.ViewModels;
using MediatR;

namespace BasicFramework.Appliction.Commands.User
{
    /// <summary>
    /// 添加用户命令
    /// </summary>
    public  class UserRegisterCommand:IRequest<ApiResult>
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
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Photo { get; set; }


    }
}
