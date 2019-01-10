using ClothingSystem.Common;
using ClothingSystem.Dto.Enum;
using ClothingSystem.Dto.Model;
using ClothingSystem.Dto.Page;
using ClothingSystem.Service.Impl;
using ClothingSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ClothingSystem.Web.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoController : BaseController
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController()
        {
            _userInfoService = new UserInfoService(_user);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">请求模型</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResponseResult<string> Login([FromBody]LoginRequestDto request)
        {
            return _userInfoService.Login(request).Success();
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Logout()
        {
            AuthUserCache.Remove(_user.Token);
            return true.Success();
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]UserInfoAddDto model)
        {
            return _userInfoService.Insert(model).Success();
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Edit([FromBody]UserInfoEditDto model)
        {
            return _userInfoService.Update(model).Success();
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model">修改对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> EditPassword([FromBody]UserEditPwdDto model)
        {
            return _userInfoService.EditPassword(model).Success();
        }

        /// <summary>
        /// 修改用户密码，管理员使用
        /// </summary>
        /// <param name="model">修改对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> ModifyPassword([FromBody]UpdatePwdDto model)
        {
            return _userInfoService.ModifyPassword(model).Success();
        }

        /// <summary>
        /// 搜索用户信息
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PageResult<UserInfoFullDto>> SearchPage(UserInfoSearchDto search)
        {
            return _userInfoService.SearchPage(search).Success();
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<UserInfoFullDto>> GetList()
        {
            return _userInfoService.GetList().Success();
        }

        /// <summary>
        /// 根据Id获取用户信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<UserInfoFullDto> Get(int id)
        {
            return _userInfoService.GetById(id).Success();
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _userInfoService.Deletes(ids).Success();
        }

        #region 扩展
        /// <summary>
        /// 解密密码
        /// </summary>
        /// <param name="encryptPwd">加密密码</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseResult<string> DecryptPwd([FromUri]string encryptPwd)
        {
            return Tools.DecryptDESByUserPwd(encryptPwd).Success();
        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="pwd">明文密码</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseResult<string> EncryptPwd([FromUri]string pwd)
        {
            return Tools.EncryptDESByUserPwd(pwd).Success();
        }

        /// <summary>
        /// 生成图形验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ResponseResult<string> ImageCode(int codeLength = 4, int codeW = 80, int codeH = 22)
        {
            var res = ImgCodeHelper.Generate(codeLength, codeW, codeH);
            ContextHelper.WriteSession(Constant.UserImgCodeKey, res.ImgCode);
            return res.FullImgBase64.Success();
        }
        #endregion
    }
}