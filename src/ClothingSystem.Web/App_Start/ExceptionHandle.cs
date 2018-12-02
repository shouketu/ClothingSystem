using ClothingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ClothingSystem.Web.App_Start
{
    /// <summary>
	/// 全局异常处理
	/// </summary>
	internal class ExceptionHandle : IExceptionHandler
    {
        /// <summary>
        /// 处理异常信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Handle(ExceptionHandlerContext context)
        {
            Exception baseException = context.Exception.GetBaseException();
            string errorCode = "UnKnown";
            string errorMessage = baseException.Message;
            var verify = baseException as VerifyException;
            if (verify != null)
            {
                errorCode = verify.ErrorCode;
                errorMessage = verify.ErrorMessage;
            }
            var value = new
            {
                Status = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
            };
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.OK, value));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            this.Handle(context);
            return Task.FromResult<bool>(true);
        }
    }
}