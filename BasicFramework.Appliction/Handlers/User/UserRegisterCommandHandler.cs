using BasicFramework.Appliction.Commands.User;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BasicFramework.Dommain.Repositorys;
using BasicFramework.Appliction.ViewModels;
using BasicFramework.Dommain.Repositorys.Base;

namespace BasicFramework.Appliction.Handlers
{
    /// <summary>
    /// 添加用户命令处理器
    /// </summary>
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand,ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userRepository"></param>
        public UserRegisterCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
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
            var model = new Dommain.Entitys.User.UserEntity(request.UserName.Trim(), request.Phone.Trim(), request.Pwd.Trim(), request.Photo.Trim(), request.QQNumber.Trim(), request.WeCharNumber.Trim(), request.Email.Trim());
            await  _userRepository.AddEntityAsync(model);
            await  _unitOfWork.CommitAsync();
            return new ApiResult { IsSuccess=true,Message="注册成功"};
        }
    }
}
