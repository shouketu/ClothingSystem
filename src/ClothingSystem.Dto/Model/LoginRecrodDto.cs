using ClothingSystem.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 登录记录
    /// </summary>
    public class LoginRecrodDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录Ip
        /// </summary>
        public string LoginIp { get; set; }

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
    }
}
