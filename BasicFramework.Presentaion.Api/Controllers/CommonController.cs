using System.Net;
using System.Threading.Tasks;
using BasicFramework.Appliction.Queries;
using BasicFramework.Appliction.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BasicFramework.Presentaion.Api.Controllers
{
    /// <summary>
    /// 公共模块
    /// </summary>
    [ApiController]
    [Route("api/commons")]
    public class CommonController : ControllerBase
    {
       
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">上传文件</param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public async Task<IActionResult> GetUserInfo(IFormFile file)
        {
           return Ok(await Task.FromResult(true));
          
        }
    }
}
