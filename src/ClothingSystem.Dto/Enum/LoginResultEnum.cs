using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Enum
{
    /// <summary>
    /// 登录返回枚举
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum LoginResultEnum
    {
        /// <summary>
        /// 无状态
        /// </summary>
        [Description("无状态")]
        None,

        /// <summary>
        /// 用户名或密码为空
        /// </summary>
        [Description("用户名或密码为空")]
        UserNameOrPasswordEmpty,

        /// <summary>
        /// 图片验证码过期
        /// </summary>
        [Description("图片验证码过期")]
        ImgCodeExpired,

        /// <summary>
        /// 图片验证码错误
        /// </summary>
        [Description("图片验证码错误")]
        ImgCodeError,

        /// <summary>
        /// 用户名或密码不正确
        /// </summary>
        [Description("用户名或密码不正确")]
        LoginError,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success,
    }
}
