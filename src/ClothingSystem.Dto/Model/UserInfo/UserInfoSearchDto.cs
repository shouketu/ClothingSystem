using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 用户信息搜索模型
    /// </summary>
    public class UserInfoSearchDto : Page.PageParameter
    {
        /// <summary>
        /// 分组Id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
