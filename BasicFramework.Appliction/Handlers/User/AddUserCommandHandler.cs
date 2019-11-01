using BasicFramework.Appliction.Commands.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BasicFramework.Appliction.Handlers.User
{
    /// <summary>
    /// 添加用户命令处理器
    /// </summary>
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        public Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
