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
        /// 名称搜索
        /// </summary>
        public string Name { get; set; }
    }
}
