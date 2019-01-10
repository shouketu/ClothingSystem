using ClothingSystem.Common;
using ClothingSystem.DAL.Impl;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto;
using ClothingSystem.Dto.Enum;
using ClothingSystem.Dto.Model;
using ClothingSystem.Dto.Page;
using ClothingSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Service.Impl
{
    public class UserInfoService : BaseService, IUserInfoService
    {
        private readonly IUserInfoDal _userInfoDal;
        private readonly IGroupInfoDal _groupInfoDal;
        private readonly ILoginRecrodService _loginRecrodService;

        public UserInfoService(AuthUserDto user) : base(user)
        {
            _userInfoDal = new UserInfoDal(user);
            _loginRecrodService = new LoginRecrodService(user);
            _groupInfoDal = new GroupInfoDal(user);
        }

        [Obsolete]
        public LoginResponseDto Login_Obsolete(LoginRequestDto request)
        {
            var userName = request.UserName;
            var userPwd = request.UserPwd;
            var imgCode = request.ImgCode;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
                return new LoginResponseDto(LoginResultEnum.UserNameOrPasswordEmpty);
            var objCode = ContextHelper.ReadSession(Constant.UserImgCodeKey);
            if (objCode == null)
                return new LoginResponseDto(LoginResultEnum.ImgCodeExpired);
            if (!objCode.ToString().Equals(imgCode, StringComparison.CurrentCultureIgnoreCase))
                return new LoginResponseDto(LoginResultEnum.ImgCodeError);
            userPwd = Tools.EncryptDESByUserPwd(userPwd);
            var model = _userInfoDal.GetByNameAndPwd(userName, userPwd);
            if (model == null)
                return new LoginResponseDto(LoginResultEnum.LoginError);

            var token = LoginAfter(model);
            return new LoginResponseDto(LoginResultEnum.Success, token);
        }

        public string Login(LoginRequestDto request)
        {
            var userName = request.UserName;
            var userPwd = request.UserPwd;
            var imgCode = request.ImgCode;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
                Exception(LoginResultEnum.UserNameOrPasswordEmpty.ToString(), "用户名或密码不能为空");
            var objCode = ContextHelper.ReadSession(Constant.UserImgCodeKey);
            if (objCode == null)
                Exception(LoginResultEnum.ImgCodeExpired.ToString(), "验证码过期，请刷新验证码");
            if (!objCode.ToString().Equals(imgCode, StringComparison.CurrentCultureIgnoreCase))
                Exception(LoginResultEnum.ImgCodeError.ToString(), "验证码错误");
            userPwd = Tools.EncryptDESByUserPwd(userPwd);
            var model = _userInfoDal.GetByNameAndPwd(userName, userPwd);
            if (model == null)
                Exception(LoginResultEnum.LoginError.ToString(), "用户名或密码不正确");

            var token = LoginAfter(model);
            return token;
        }

        public PageResult<UserInfoFullDto> SearchPage(UserInfoSearchDto search)
        {
            AdminVerify(search, "SearchPage");

            search = search ?? new UserInfoSearchDto();
            search.PageSize = search.PageSize < 1 ? 50 : search.PageSize;
            search.PageIndex = search.PageIndex < 1 ? 1 : search.PageIndex;
            var res = _userInfoDal.SearchPage(search);
            if (res.Items.Count > 0)
            {
                var list = _groupInfoDal.GetList(res.Items.Select(p => p.GroupId).ToArray());
                foreach (var item in res.Items)
                {
                    item.GroupInfo = list.Find(p => p.Id == item.GroupId);
                }
            }
            return res;
        }

        public List<UserInfoFullDto> GetList(params int[] ids)
        {
            AdminVerify(0, "GetList");
            return _userInfoDal.GetList(ids);
        }

        public UserInfoFullDto GetById(int id)
        {
            AdminVerify(id, "GetById");
            var res = _userInfoDal.GetById(id);
            if (res != null)
                res.GroupInfo = _groupInfoDal.GetById(res.GroupId);
            return res;
        }

        public bool Insert(UserInfoAddDto model)
        {
            Verify(model);

            if (string.IsNullOrEmpty(model.UserPwdText))
                Exception("Insert.UserPwdText", "密码不能为空");
            
            var info = model.Clone<UserInfoDto>();
            var nameModel = _userInfoDal.GetByName(info.UserName);
            if (nameModel != null)
                Exception("Insert.UserName", "用户名已存在");

            info.UserPwd = Tools.EncryptDESByUserPwd(info.UserPwdText);
            return _userInfoDal.Insert(info) > 0;
        }

        public bool Update(UserInfoEditDto model)
        {
            Verify(model);

            var nameModel = _userInfoDal.GetByName(model.UserName);
            if (nameModel != null && nameModel.Id != model.Id)
                Exception("Update.UserName", "用户名已存在");

            return _userInfoDal.Update(model) > 0;
        }

        private void Verify(UserInfoAddDto model)
        {
            AdminVerify(model, "Verify");
            //if (_user.UserType == Common.UserTypeEnum.UserInfo)
            //    Exception("Verify.UserType", "无法进行此操作");

            //if (model == null)
            //    Exception("Verify.model", "参数不能为空");

            if (string.IsNullOrEmpty(model.UserName))
                Exception("Verify.UserName", "用户名不能为空");
        }

        private string LoginAfter(UserInfoDto model)
        {
            if (model == null)
                return null;
            // ContextHelper.WriteSession(Constant.UserSessionKey, model);
            _loginRecrodService.UserInsert(model.Id, model.UserName);
            ContextHelper.WriteSession(Constant.UserImgCodeKey, null);
            

            var token = Tools.GetToken(model);
            var user = new AuthUserDto { UserId = model.Id, UserName = model.UserName, UserType = Common.UserTypeEnum.UserInfo, Token = token };
            AuthUserCache.Set(token, user);

            ContextHelper.WriteCookie(Constant.UserCookieKey, token);
            return token;
        }
        
        public bool Deletes(params int[] ids)
        {
            AdminVerify(ids, "Deletes");

            if (ids == null || ids.Length < 1)
                return true;
            return _userInfoDal.Deletes(ids) > 0;
        }

        public bool EditPassword(UserEditPwdDto model)
        {
            if (_user == null)
                Exception("Update.EditPassword", "修改用户不存在");

            if (model == null)
                Exception("Update.EditPassword", "修改用户不存在");

            if(string.IsNullOrEmpty(model.OldPwd))
                Exception("Update.EditPassword", "旧密码不能为空");

            if (string.IsNullOrEmpty(model.NewPwd))
                Exception("Update.EditPassword", "新密码不能为空");

            if (!model.NewPwd.Equals(model.ReNewPwd))
                Exception("Update.EditPassword", "两次密码不一致");

            var info = _userInfoDal.GetById(_user.UserId);
            if (info == null)
                Exception("Update.EditPassword", "修改用户在数据库中不存在");

            if(Tools.DecryptDESByUserPwd(info.UserPwd) != model.OldPwd)
                Exception("Update.EditPassword", "旧密码不正确");

            var pwd = Tools.EncryptDESByUserPwd(model.NewPwd);

            return _userInfoDal.Update(_user.UserId, pwd) > 0;
        }

        public bool ModifyPassword(UpdatePwdDto model)
        {
            if (model == null || model.UserId <= 0)
                Exception("Update.ModifyPPassword", "修改用户不存在");

            if (string.IsNullOrEmpty(model.UserPwdText))
                Exception("Update.ModifyPPassword", "密码不能为空");

            var pwd = Tools.EncryptDESByUserPwd(model.UserPwdText);

            return _userInfoDal.Update(model.UserId, pwd) > 0;
        }
    }
}
