using ClothingSystem.Common;
using ClothingSystem.Dto.Enum;
using ClothingSystem.Dto.Model;
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