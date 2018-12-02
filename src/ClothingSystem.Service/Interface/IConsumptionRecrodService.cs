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
    /// 消费记录服务
    /// </summary>
    public interface IConsumptionRecrodService
    {
        /// <summary>
        /// 插入消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Insert(ConsumptionRecrodAddDto model);

        /// <summary>
        /// 编辑消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Update(ConsumptionRecrodEditDto model);

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        PageResult<ConsumptionRecrodDto> SearchPage(ConsumptionRecrodSearchDto search);

        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        ConsumptionRecrodDto GetById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        bool Deletes(params int[] ids);
    }
}
