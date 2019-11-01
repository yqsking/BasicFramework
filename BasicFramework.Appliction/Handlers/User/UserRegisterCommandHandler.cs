using BasicFramework.Appliction.Commands.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BasicFramework.Dommain.Repositorys;
using BasicFramework.Appliction.ViewModels;

namespace BasicFramework.Appliction.Handlers.User
{
    /// <summary>
    /// 添加用户命令处理器
    /// </summary>
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand,ApiResult>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UserRegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<ApiResult> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            bool exists=await  _userRepository.ExistAsync(item=>item.Phone==request.Phone.Trim());
            if(exists)
            {
                return new ApiResult { IsSuccess=false,Message=$"抱歉,手机号：{request.Phone.Trim()}已被注册！"};
            }
            var result=await  _userRepository.AddEntityAsync(new Dommain.Entitys.User.UserEntity(request.UserName,request.Phone,request.Pwd));
            return new ApiResult { IsSuccess=result,Message=result?"注册成功！":"注册失败！"};
        }
    }
}
