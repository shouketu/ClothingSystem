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
    /// 分组信息
    /// </summary>
    public class GroupInfoController : BaseController
    {
        private readonly IGroupInfoService _groupInfoService;
        public GroupInfoController()
        {
            _groupInfoService = new GroupInfoService(_user);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]GroupInfoAddDto model)
        {
            return _groupInfoService.Insert(model).Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Edit([FromBody]GroupInfoEditDto model)
        {
            return _groupInfoService.Update(model).Success();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<GroupInfoFullDto>> GetList()
        {
            var res = _groupInfoService.GetList();
            //return res.Clone<List<GroupInfoEditDto>>().Success();
            return res.Success();
        }

        /// <summary>
        /// 获取指定分组
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<GroupInfoFullDto> Get([FromUri]int id)
        {
            return _groupInfoService.GetById(id).Success();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _groupInfoService.Deletes(ids).Success();
        }
    }
}