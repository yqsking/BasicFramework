using BasicFramework.Appliction.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicFramework.Appliction.Queries
{
    /// <summary>
    /// 用户模块服务
    /// </summary>
    public  interface IUserQueries
    {
        /// <summary>
        /// 根据Id获取用户基础信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponseDto> GetUserById(string id);
    }
}
