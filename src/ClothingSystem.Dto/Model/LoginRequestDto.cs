using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 登录请求模型
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码（明文）
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 图片验证码
        /// </summary>
        public string ImgCode { get; set; }
    }
}
