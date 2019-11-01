using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicFramework.Appliction.Commands.User;
using BasicFramework.Appliction.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicFramework.Presentaion.Api.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="userQueries"></param>
        public UserController(IMediator mediator,IUserQueries userQueries)
        {
            _mediator = mediator;
            _userQueries = userQueries;
        }
        
        /// <summary>
        /// 根据id获取用户基础信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute]string id)
        {
           var result=await  _userQueries.GetUserById(id);
            return Ok(result);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("users/userRegister")]
        public async Task<IActionResult> UserRegister([FromBody]UserRegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
