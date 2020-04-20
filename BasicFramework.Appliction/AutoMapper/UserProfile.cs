using AutoMapper;
using BasicFramework.Appliction.ViewModels.User;
using BasicFramework.Dommain.Entitys.User;

namespace BasicFramework.Appliction.AutoMapper
{
    /// <summary>
    /// 用户模块dto映射
    /// </summary>
    public  class UserProfile:Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public UserProfile()
        {
            CreateMap<UserBasicEntity,UserResponseDto>();
        }
    }
}
