using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserInfoDto : UserInfoEditDto
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 创建的管理员Id
        /// </summary>
        public int AdminId { get; set; }

        /// <summary>
        /// 创建的管理员名称
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 用户密码（密文）
        /// </summary>
        public string UserPwd { get; set; }
    }
}
