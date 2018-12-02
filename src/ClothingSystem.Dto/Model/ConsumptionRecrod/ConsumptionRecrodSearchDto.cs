using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 消费记录搜索模型
    /// </summary>
    public class ConsumptionRecrodSearchDto : Page.PageParameter
    {
        /// <summary>
        /// 顾客Id
        /// </summary>
        public int? CustomerInfoId { get; set; }
    }
}
