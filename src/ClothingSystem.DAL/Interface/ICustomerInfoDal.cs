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
    /// 顾客信息操作数据
    /// </summary>
    public interface ICustomerInfoDal
    {
        /// <summary>
        /// 插入顾客
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Insert(CustomerInfoDto model);

        /// <summary>
        /// 编辑顾客
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Update(CustomerInfoEditDto model);

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        PageResult<CustomerInfoFullDto> SearchPage(CustomerSearchDto search);

        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        CustomerInfoFullDto GetById(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        int Deletes(params int[] ids);
    }
}
