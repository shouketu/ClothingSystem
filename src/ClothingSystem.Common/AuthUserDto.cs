using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    /// <summary>
    /// 请求用户模型
    /// </summary>
    public class AuthUserDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserTypeEnum UserType { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string Token { get; set; }
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum UserTypeEnum
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Administrator,

        /// <summary>
        /// 用户信息
        /// </summary>
        [Description("用户信息")]
        UserInfo
    }
}
