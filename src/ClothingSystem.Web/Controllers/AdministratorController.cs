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
    /// 管理员信息
    /// </summary>
    public class AdministratorController : BaseController
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController()
        {
            _administratorService = new AdministratorService(_user);
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
            return _administratorService.Login(request).Success();
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]AdministratorAddDto model)
        {
            return _administratorService.Insert(model).Success();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> UpdatePwd([FromBody]UpdatePwdDto model)
        {
            return _administratorService.UpdatePwd(model).Success();
        }

        /// <summary>
        /// 获取管理员对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<AdministratorDto> Get([FromUri]int id)
        {
            return _administratorService.GetById(id).Success();
        }

        /// <summary>
        /// 获取管理员对象集合
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<AdministratorDto>> GetList()
        {
            return _administratorService.GetList().Success();
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _administratorService.Deletes(ids).Success();
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
            return Tools.DecryptDESByAdminPwd(encryptPwd).Success();
        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="pwd">明文密码</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseResult<string> EncryptPwd([FromUri]string pwd)
        {
            return Tools.EncryptDESByAdminPwd(pwd).Success();
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
            ContextHelper.WriteSession(Constant.AdminImgCodeKey, res.ImgCode);
            return res.FullImgBase64.Success();
        }
        #endregion
    }
}