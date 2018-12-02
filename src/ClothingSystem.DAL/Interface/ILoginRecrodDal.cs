using ClothingSystem.Dto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Interface
{
    /// <summary>
    /// 登录记录数据操作
    /// </summary>
    public interface ILoginRecrodDal
    {
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model">记录对象</param>
        /// <returns></returns>
        int Insert(LoginRecrodDto model);
    }
}
