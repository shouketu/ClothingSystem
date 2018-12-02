using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 管理员数据操作类
    /// </summary>
    public interface IAdministratorDal
    {
        /// <summary>
        /// 根据管理名称和密码判断是否存在
        /// </summary>
        /// <param name="adminName">管理名称</param>
        /// <param name="adminPwd">密码</param>
        /// <returns></returns>
        bool ExistByNameAndPwd(string adminName, string adminPwd);

        /// <summary>
        /// 根据管理名称和密码获取管理员信息
        /// </summary>
        /// <param name="adminName">账号</param>
        /// <param name="adminPwd">密码</param>
        /// <returns></returns>
        AdministratorDto GetByNameAndPwd(string adminName, string adminPwd);

        /// <summary>
        /// 根据管理名称获取管理员信息
        /// </summary>
        /// <param name="adminName">账号</param>
        /// <returns></returns>
        AdministratorDto GetByName(string adminName);

        /// <summary>
        /// 根据Id获取管理员对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        AdministratorDto GetById(int id);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<AdministratorDto> GetList();

        /// <summary>
        /// 插入管理员
        /// </summary>
        /// <param name="model">管理员对象</param>
        /// <returns></returns>
        int Insert(AdministratorDto model);

        /// <summary>
        /// 更新管理员最后登录时间和Ip
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="lastLoginTime">最后登录时间</param>
        /// <param name="lastLoginIp">最后登录Ip</param>
        /// <returns></returns>
        int Update(int id, DateTime lastLoginTime, string lastLoginIp);

        /// <summary>
        /// 更改管理员密码
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="adminPwd">新密码</param>
        /// <returns></returns>
        int Update(int id, string adminPwd);
    }
}
