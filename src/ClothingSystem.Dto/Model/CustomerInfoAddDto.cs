using ClothingSystem.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 顾客信息添加模型
    /// </summary>
    public class CustomerInfoAddDto
    {
        /// <summary>
        /// 创建用户类型
        /// </summary>
        public UserTypeEnum CreateType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 授权地址
        /// </summary>
        public string AuthAddress { get; set; }

        /// <summary>
        /// 进货折扣
        /// </summary>
        public decimal PurchaseDiscount { get; set; }

        /// <summary>
        /// 首批款项
        /// </summary>
        public decimal FirstPayment { get; set; }

        /// <summary>
        /// 发货款项
        /// </summary>
        public decimal ShipmentPayment { get; set; }

        /// <summary>
        /// 签约经理
        /// </summary>
        public string ContractManager { get; set; }

        /// <summary>
        /// 加入日期
        /// </summary>
        public DateTime JoinTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 所属分组
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        public int UserId { get; set; }
    }
}
