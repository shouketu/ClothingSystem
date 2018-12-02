using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Interface
{
    /// <summary>
    /// 分组信息服务
    /// </summary>
    public interface IGroupInfoService
    {
        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        GroupInfoDto GetById(int id);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Insert(GroupInfoAddDto model);

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        List<GroupInfoDto> GetList();

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        bool Update(GroupInfoEditDto model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        bool Deletes(params int[] ids);
    }
}
