using ClothingSystem.Common;
using ClothingSystem.DAL.Impl;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto.Enum;
using ClothingSystem.Dto.Model;
using ClothingSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Impl
{
    public class AdministratorService : BaseService, IAdministratorService
    {
        private readonly IAdministratorDal _administratorDal;
        private readonly ILoginRecrodService _loginRecrodService;

        public AdministratorService(AuthUserDto user) : base(user)
        {
            _administratorDal = new AdministratorDal(user);
            _loginRecrodService = new LoginRecrodService(user);
        }

        public string Login(LoginRequestDto request)
        {
            var userName = request.UserName;
            var userPwd = request.UserPwd;
            var imgCode = request.ImgCode;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
                Exception(LoginResultEnum.UserNameOrPasswordEmpty.ToString(), "用户名或密码不能为空");
            var objCode = ContextHelper.ReadSession(Constant.AdminImgCodeKey);
            if (objCode == null)
                Exception(LoginResultEnum.ImgCodeExpired.ToString(), "验证码过期，请刷新验证码");
            if (!objCode.ToString().Equals(imgCode, StringComparison.CurrentCultureIgnoreCase))
                Exception(LoginResultEnum.ImgCodeError.ToString(), "验证码错误");
            userPwd = Tools.EncryptDESByAdminPwd(userPwd);
            var model = _administratorDal.GetByNameAndPwd(userName, userPwd);
            if (model == null)
                Exception(LoginResultEnum.LoginError.ToString(), "用户名或密码不正确");

            var token = LoginAfter(model);
            return token;
        }

        public bool Insert(AdministratorAddDto model)
        {
            Verify(model);

            if (string.IsNullOrEmpty(model.AdminPwdText))
                Exception("Insert.UserPwdText", "密码不能为空");

            var info = model.Clone<AdministratorDto>();
            var nameModel = _administratorDal.GetByName(info.AdminName);
            if (nameModel != null)
                Exception("Insert.UserName", "用户名已存在");

            info.CreateTime = DateTime.Now;
            info.LastLoginTime = DateTime.Now;
            info.AdminPwd = Tools.EncryptDESByAdminPwd(info.AdminPwdText);
            return _administratorDal.Insert(info) > 0;
        }

        public bool UpdatePwd(UpdatePwdDto model)
        {
            AdminVerify(model, "UpdatePwd");
            //if (_user.UserType == Common.UserTypeEnum.UserInfo)
            //    Exception("UpdatePwd.UserType", "无法进行此操作");

            //if (model == null)
            //    Exception("UpdatePwd.model", "参数不能为空");

            if (string.IsNullOrEmpty(model.UserPwdText))
                Exception("UpdatePwd.UserPwdText", "密码不能为空");

            var adminPwd = Tools.EncryptDESByAdminPwd(model.UserPwdText);
            return _administratorDal.Update(model.UserId, adminPwd) > 0;
        }

        public bool EditPassword(UserEditPwdDto model)
        {
            if (_user == null)
                Exception("Update.EditPassword", "修改用户不存在");

            if (model == null)
                Exception("Update.EditPassword", "修改用户不存在");

            if (string.IsNullOrEmpty(model.OldPwd))
                Exception("Update.EditPassword", "旧密码不能为空");

            if (string.IsNullOrEmpty(model.NewPwd))
                Exception("Update.EditPassword", "新密码不能为空");

            if (!model.NewPwd.Equals(model.ReNewPwd))
                Exception("Update.EditPassword", "两次密码不一致");

            var info = _administratorDal.GetById(_user.UserId);
            if (info == null)
                Exception("Update.EditPassword", "修改用户在数据库中不存在");

            if (Tools.DecryptDESByAdminPwd(info.AdminPwd) != model.OldPwd)
                Exception("Update.EditPassword", "旧密码不正确");

            var pwd = Tools.EncryptDESByAdminPwd(model.NewPwd);

            return _administratorDal.Update(_user.UserId, pwd) > 0;
        }

        public AdministratorDto GetById(int id)
        {
            AdminVerify(0, "GetById");
            return _administratorDal.GetById(id);
        }

        public List<AdministratorDto> GetList()
        {
            AdminVerify(0, "GetList");
            return _administratorDal.GetList();
        }

        private void Verify(AdministratorAddDto model)
        {
            AdminVerify(model, "Verify");
            //if (_user.UserType == Common.UserTypeEnum.UserInfo)
            //    Exception("Verify.UserType", "无法进行此操作");

            //if (model == null)
            //    Exception("Verify.model", "参数不能为空");

            if (string.IsNullOrEmpty(model.AdminName))
                Exception("Verify.UserName", "管理员名称不能为空");
        }

        private string LoginAfter(AdministratorDto model)
        {
            if (model == null)
                return null;

            _loginRecrodService.AdminInsert(model.Id, model.AdminName);
            _administratorDal.Update(model.Id, DateTime.Now, ContextHelper.GetIp());
            ContextHelper.WriteSession(Constant.AdminImgCodeKey, null);

            var token = Tools.GetToken(model);
            var user = new AuthUserDto { UserId = model.Id, UserName = model.AdminName, UserType = Common.UserTypeEnum.Administrator, Token = token };
            AuthUserCache.Set(token, user);

            ContextHelper.WriteCookie(Constant.AdminCookieKey, token);
            return token;
        }

        public bool Deletes(params int[] ids)
        {
            AdminVerify(ids, "Deletes");
            if (ids.Contains(1))
                Exception("Deletes.Administraotr", "Admin管理员不能删除");

            return _administratorDal.Deletes(ids) > 0;
        }
    }
}
