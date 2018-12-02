using ClothingSystem.Dto.Model;
using ClothingSystem.Dto.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Interface
{
    /// <summary>
    /// 顾客信息服务
    /// </summary>
    public interface ICustomerInfoService
    {
        /// <summary>
        /// 插入顾客
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Insert(CustomerInfoAddDto model);

        /// <summary>
        /// 编辑顾客
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Update(CustomerInfoEditDto model);

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        PageResult<CustomerInfoDto> SearchPage(CustomerSearchDto search);
    }
}
