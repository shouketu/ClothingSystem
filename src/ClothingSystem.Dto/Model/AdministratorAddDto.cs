using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 管理员添加模型
    /// </summary>
    public class AdministratorAddDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 用户密码（明文）
        /// </summary>
        public string AdminPwdText { get; set; }
    }
}
