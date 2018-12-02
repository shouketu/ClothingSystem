using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Interface
{
    /// <summary>
    /// 登录记录服务
    /// </summary>
    public interface ILoginRecrodService
    {
        /// <summary>
        /// 管理员添加记录
        /// </summary>
        /// <param name="adminId">管理员Id</param>
        /// <param name="adminName">管理员名称</param>
        /// <returns></returns>
        bool AdminInsert(int adminId, string adminName);

        /// <summary>
        /// 用户添加记录
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        bool UserInsert(int userId, string userName);
    }
}
