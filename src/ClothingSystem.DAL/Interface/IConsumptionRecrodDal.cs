using ClothingSystem.Dto.Model;
using ClothingSystem.Dto.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 消费记录操作数据
    /// </summary>
    public interface IConsumptionRecrodDal
    {
        /// <summary>
        /// 插入消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Insert(ConsumptionRecrodDto model);

        /// <summary>
        /// 编辑消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Update(ConsumptionRecrodEditDto model);

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
        int Deletes(params int[] ids);
    }
}
