using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 顾客信息所有数据模型
    /// </summary>
    public class CustomerInfoFullDto : CustomerInfoDto
    {
        /// <summary>
        /// 分组对象
        /// </summary>
        public GroupInfoFullDto GroupInfo { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupTitle => GroupInfo?.Title;

        /// <summary>
        /// 用户对象
        /// </summary>
        public UserInfoFullDto UserInfo { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName => UserInfo?.UserName;
    }
}
