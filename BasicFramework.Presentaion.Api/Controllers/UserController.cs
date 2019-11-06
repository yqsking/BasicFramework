using System.Net;
using System.Threading.Tasks;
using BasicFramework.Appliction.Queries;
using BasicFramework.Appliction.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BasicFramework.Presentaion.Api.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserQueries _userQueries;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="userQueries"></param>
        public UserController(IMediator mediator, IUserQueries userQueries)
        {
            _mediator = mediator;
            _userQueries = userQueries;
        }

        /// <summary>
        /// 获取指定用户信息
        /// </summary>
        /// <param name="id">用户唯一id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserResponseDto))]
        public async Task<IActionResult> GetUserInfo([FromRoute]string id)
        {
           //var result=await  _userQueries.GetUserById(id);
           return Ok(await Task.FromResult(new UserResponseDto { UserName = "saber" }));
          
        }
    }
}
