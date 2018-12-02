using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 管理员模型
    /// </summary>
    public class AdministratorDto : AdministratorAddDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 密码（官方）
        /// </summary>
        public string AdminPwd { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后登录Ip
        /// </summary>
        public string LastLoginIp { get; set; }
    }
}
