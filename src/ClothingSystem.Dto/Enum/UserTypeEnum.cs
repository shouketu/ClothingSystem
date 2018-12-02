using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Enum
{
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
