using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    /// <summary>
    /// 响应结果模型
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class ResponseResult<T>
    {
        /// <summary>
        /// 请求状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }

    public static class ResponseResultExpansion
    {
        public static ResponseResult<T> Error<T>(this T data, string message = null, string code = null)
        {
            return new ResponseResult<T>() { Status = false, ErrorMessage = message, Data = data, ErrorCode = code };
        }

        public static ResponseResult<T> Success<T>(this T data)
        {
            return new ResponseResult<T>() { Status = true, Data = data };
        }
    }
}
