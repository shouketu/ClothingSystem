using ClothingSystem.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 创建模型
    /// </summary>
    public class CreateDto
    {
        /// <summary>
        /// 创建用户Id
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int CreateId { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string CreateName { get; set; }

        /// <summary>
        /// 创建用户类型
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public UserTypeEnum CreateType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public DateTime CreateTime { get; set; }
    }
}
