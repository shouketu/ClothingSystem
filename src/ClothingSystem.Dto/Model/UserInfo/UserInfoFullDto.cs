using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 用户信息所有数据模型
    /// </summary>
    public class UserInfoFullDto : UserInfoDto
    {
        /// <summary>
        /// 分组对象
        /// </summary>
        public GroupInfoFullDto GroupInfo { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupTitle => GroupInfo?.Title;
    }
}
