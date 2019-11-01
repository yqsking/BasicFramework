using AutoMapper;

namespace BasicFramework.Appliction.AutoMapper.User
{
    /// <summary>
    /// 用户模块映射
    /// </summary>
    public  class UserProfile:Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public UserProfile()
        {
            CreateMap<Dommain.Entitys.User.UserEntity, ViewModels.User.UserResponseDto>();
        }
    }
}
