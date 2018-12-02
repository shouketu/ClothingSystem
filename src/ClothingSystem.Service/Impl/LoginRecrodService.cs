using ClothingSystem.Common;
using ClothingSystem.DAL.Impl;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto;
using ClothingSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Impl
{
    public class LoginRecrodService : BaseService, ILoginRecrodService
    {
        private readonly ILoginRecrodDal _loginRecrodDal;
        public LoginRecrodService(AuthUserDto user) : base(user)
        {
            _loginRecrodDal = new LoginRecrodDal(user);
        }
        public bool AdminInsert(int adminId, string adminName)
        {
            var model = Get(Dto.Enum.UserTypeEnum.Administrator);
            model.UserId = adminId;
            model.UserName = adminName;
            return _loginRecrodDal.Insert(model) > 0;
        }

        public bool UserInsert(int userId, string userName)
        {
            var model = Get(Dto.Enum.UserTypeEnum.UserInfo);
            model.UserId = userId;
            model.UserName = userName;
            return _loginRecrodDal.Insert(model) > 0;
        }

        private Dto.Model.LoginRecrodDto Get(Dto.Enum.UserTypeEnum type)
        {
            return new Dto.Model.LoginRecrodDto()
            {
                LoginIp = ContextHelper.GetIp(),
                LoginTime = DateTime.Now,
                UserType = type
            };
        }
    }
}
