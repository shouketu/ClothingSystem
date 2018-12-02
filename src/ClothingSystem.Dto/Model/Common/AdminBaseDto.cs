using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 管理员基类模型
    /// </summary>
    public class AdminBaseDto
    {
        /// <summary>
        /// 管理员Id
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int AdminId { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string AdminName { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public DateTime CreateTime { get; set; }
    }
}
