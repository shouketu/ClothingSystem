using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Interface
{
    /// <summary>
    /// 管理员服务
    /// </summary>
    public interface IAdministratorService
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="request">登录对象</param>
        /// <returns></returns>
        string Login(LoginRequestDto request);

        /// <summary>
        /// 插入管理员
        /// </summary>
        /// <param name="model">管理员对象</param>
        /// <returns></returns>
        bool Insert(AdministratorAddDto model);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码对象<param>
        /// <returns></returns>
        bool UpdatePwd(UpdatePwdDto model);

        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        AdministratorDto GetById(int id);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<AdministratorDto> GetList();
    }
}
