using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 分组信息所有数据模型
    /// </summary>
    public class GroupInfoFullDto : GroupInfoDto
    {
        /// <summary>
        /// 项目对象
        /// </summary>
        public ProjectInfoDto ProjectInfo { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectTtile => ProjectInfo?.Title;
    }
}
