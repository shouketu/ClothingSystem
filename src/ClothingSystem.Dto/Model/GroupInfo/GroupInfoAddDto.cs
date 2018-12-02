using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 分组添加模型
    /// </summary>
    public class GroupInfoAddDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId { get; set; }
    }
}
