using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 消费记录添加模型
    /// </summary>
    public class ConsumptionRecrodAddDto : CreateDto
    {
        /// <summary>
        /// 顾客Id
        /// </summary>
        public int CustomerInfoId { get; set; }

        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
