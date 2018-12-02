using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 项目信息模型
    /// </summary>
    public class ProjectInfoDto: ProjectInfoEditDto
    { 
        /// <summary>
        /// 管理员Id
        /// </summary>
        public int AdminId { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
