using ClothingSystem.Common;
using ClothingSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service
{
    public class BaseService
    {
        protected readonly AuthUserDto _user;
        public BaseService(AuthUserDto user)
        {
            _user = user;
        }

        protected void Exception(string code, string message)
        {
            throw new VerifyException(code, message);
        }

        protected void AdminVerify<T>(T model, string method)
        {
            if (_user.UserType == UserTypeEnum.UserInfo)
                Exception(method + ".UserType", "无法进行此操作");

            if (model == null)
                Exception(method + ".model", "参数不能为空");
        }
    }
}
