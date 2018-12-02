using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 项目信息操作数据
    /// </summary>
    public interface IProjectInfoDal
    {
        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        ProjectInfoDto GetById(int id);

        /// <summary>
        /// 根据标题获取对象
        /// </summary>
        /// <param name="title">标题</param>
        /// <returns></returns>
        ProjectInfoDto GetByTitle(string title);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Insert(ProjectInfoDto model);

        /// <summary>
        /// 获取所有项目
        /// </summary>
        /// <returns></returns>
        List<ProjectInfoDto> GetList();

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Update(ProjectInfoEditDto model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        int Deletes(params int[] ids);
    }
}
