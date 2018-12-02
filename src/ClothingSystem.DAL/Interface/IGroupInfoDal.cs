using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 分组信息操作数据
    /// </summary>
    public interface IGroupInfoDal
    {
        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        GroupInfoFullDto GetById(int id);

        /// <summary>
        /// 根据标题获取对象
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns></returns>
        GroupInfoFullDto GetByTitle(string title);

        /// <summary>
        /// 获取所有分组
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <returns></returns>
        List<GroupInfoFullDto> GetList(params int[] ids);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Insert(GroupInfoDto model);
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Update(GroupInfoEditDto model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        int Deletes(params int[] ids);
    }
}
