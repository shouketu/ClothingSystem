using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 修改密码模型
    /// </summary>
    public class UpdatePwdDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户密码（明文）
        /// </summary>
        public string UserPwdText { get; set; }
    }
}
