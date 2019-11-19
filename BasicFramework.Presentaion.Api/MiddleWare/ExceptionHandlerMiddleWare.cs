using BasicFramework.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicFramework.Presentaion.Api.MiddleWare
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public  class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
      //  /// <param name="logger"></param>
        public ExceptionHandlerMiddleWare(RequestDelegate next/*,ILogger logger*/)      
        {
            _next = next;
           // _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            //基于guid生成一个唯一标识
            var ticketId = Guid.NewGuid().ToString();
            var requestToString = await RequestToString(context.Request, ticketId);
            try
            {
                await _next.Invoke(context);
            }
            catch(Exception ex)
            {
               
                await HandleExceptionAsync(context, ex, ticketId, requestToString);
            }
        }

        /// <summary>
        /// 处理异常信息
        /// </summary>
        private Task HandleExceptionAsync(HttpContext context, Exception ex, string ticketId, string requestString)
        {
            //// 自定义异常
            //if (ex is TrackingYeeException trackingYeeException)
            //{
            //    var errorCode = trackingYeeException.ErrorCode;
            //    var errorMsg = trackingYeeException.CustomMessage;

            //    var metadata = new ErrorData(errorCode, errorMsg, context.Request.GetAbsoluteUri())
            //    {
            //        TicketId = ticketId,
            //    };

            //    _logger.LogWarning(ex, requestString);

            //    var response = context.Response;
            //    response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    response.ContentType = "application/json;charset=utf-8";

            //    return context.Response.WriteAsync(JsonConvert.SerializeObject(metadata));
            //}
            ////序列化异常
            //else if (ex is System.Runtime.Serialization.SerializationException)
            //{
            //    var metadata = new ErrorData(string.Empty, string.Format("序列化发生异常，可能提交的数据格式有误：{0}", ex.Message), context.Request.GetAbsoluteUri())
            //    {
            //        TicketId = ticketId,
            //    };

            //    _logger.LogError(ex, requestString);

            //    var response = context.Response;
            //    response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    response.ContentType = "application/json;charset=utf-8";
            //    return context.Response.WriteAsync(_jsonConverter.SerializeObject(metadata));
            //}
            ////未处理异常
            //else
            //{
            //    var metadata = new ErrorData(string.Empty, string.Format("抱歉！发现系统异常，请您用此TicketId:{0}联系系统管理员，我们将以最快的速度为您解决此问题，谢谢！", ticketId), context.Request.GetAbsoluteUri())
            //    {
            //        TicketId = ticketId,
            //    };

            //    _logger.LogError(ex, requestString);

            //    var response = context.Response;
            //    response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //    response.ContentType = "application/json;charset=utf-8";
            //    return context.Response.WriteAsync(_jsonConverter.SerializeObject(metadata));
            //}
            return context.Response.WriteAsync(requestString);
        }

        /// <summary>
        /// 获取请求日志
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        private async Task<string> RequestToString(HttpRequest request, string ticketId = "")
        {
            var message = new StringBuilder();

            if (!string.IsNullOrEmpty(ticketId))
            {
                message.AppendLine($"[TicketId]: {ticketId} ");
            }

            if (request.Method != null)
            {
                message.AppendLine($"[Method]: {request.Method} ");
            }

            message.AppendLine($"[RequestUri]: {request.GetAbsoluteUri()} ");

            //头部Header
            if (request.Headers != null)
            {
                message.AppendLine("[Header] Values: ");
                foreach (var headerItem in request.Headers)
                {
                    message.AppendLine($"--> [{headerItem.Key}]: {headerItem.Value} ");
                }
            }
            //Body
            if (!string.IsNullOrWhiteSpace(request.Method)&& !request.Method.ToUpper().Equals("GET") && !request.Headers["Content-Type"].ToString().ToLower().Equals("multipart/form-data"))
            {
                request.EnableBuffering();

                await request.Body.DrainAsync(CancellationToken.None);
                request.Body.Seek(0L, SeekOrigin.Begin);

                var bodyContent = string.Empty;

                await using (var ms = new MemoryStream(2048))
                {
                    request.Body.Position = 0;
                    request.Body.CopyTo(ms);
                    var content = ms.ToArray();
                    bodyContent = Encoding.UTF8.GetString(content);
                }

                message.AppendLine("[Body]: ");
                message.AppendLine($"--> {bodyContent}");

                request.Body.Seek(0L, SeekOrigin.Begin);
            }

            return message.ToString();
        }
    }
}
