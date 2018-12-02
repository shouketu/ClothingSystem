using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 顾客搜索模型
    /// </summary>
    public class CustomerSearchDto : Page.PageParameter
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 名称搜索
        /// </summary>
        public string Name { get; set; }
    }
}
