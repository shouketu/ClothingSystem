using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 用户信息添加模型
    /// </summary>
    public class UserInfoAddDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码（明文）
        /// </summary>
        public string UserPwdText { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        public int GroupId { get; set; }
    }
}
