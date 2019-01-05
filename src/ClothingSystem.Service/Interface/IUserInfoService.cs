using ClothingSystem.Dto.Enum;
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
    /// 用户信息服务
    /// </summary>
    public interface IUserInfoService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        LoginResponseDto Login_Obsolete(LoginRequestDto request);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        string Login(LoginRequestDto request);

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        PageResult<UserInfoFullDto> SearchPage(UserInfoSearchDto search);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <returns></returns>
        List<UserInfoFullDto> GetList(params int[] ids);

        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        UserInfoFullDto GetById(int id);

        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        bool Insert(UserInfoAddDto model);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        bool Update(UserInfoEditDto model);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model">更改对象</param>
        /// <returns></returns>
        bool EditPassword(UserEditPwdDto model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键Id数组</param>
        /// <returns></returns>
        bool Deletes(params int[] ids);
    }
}
