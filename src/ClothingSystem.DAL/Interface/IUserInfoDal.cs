﻿using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 用户信息数据操作类
    /// </summary>
    public interface IUserInfoDal
    {
        /// <summary>
        /// 根据用户名和密码判断是否存在
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        bool ExistByNameAndPwd(string userName, string userPwd);

        /// <summary>
        /// 根据用户名和密码获取对象
        /// </summary>
        /// <param name="adminName">用户名</param>
        /// <param name="adminPwd">密码</param>
        /// <returns></returns>
        UserInfoDto GetByNameAndPwd(string userName, string userPwd);

        /// <summary>
        /// 根据用户名获取用户对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        UserInfoDto GetByName(string userName);

        /// <summary>
        /// 根据Id获取用户对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        UserInfoDto GetById(int id);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        List<UserInfoDto> GetList();

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        int Insert(UserInfoDto model);

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="userPwd">新密码</param>
        /// <returns></returns>
        int Update(int id, string userPwd);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        int Update(UserInfoEditDto model);
    }
}