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
        /// 用户密码（密文）
        /// </summary>
        public string UserPwd { get; set; }
    }
}
