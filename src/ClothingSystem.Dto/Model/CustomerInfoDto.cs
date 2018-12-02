using ClothingSystem.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 顾客信息
    /// </summary>
    public class CustomerInfoDto : CustomerInfoEditDto
    {
        /// <summary>
        /// 创建用户Id
        /// </summary>
        public int CreateId { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
