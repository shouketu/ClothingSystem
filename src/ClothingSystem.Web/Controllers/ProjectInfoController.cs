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
    /// 项目信息
    /// </summary>
    public class ProjectInfoController : BaseController
    {
        private readonly IProjectInfoService _projectInfoService;
        public ProjectInfoController()
        {
            _projectInfoService = new ProjectInfoService(_user);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]ProjectInfoAddDto model)
        {
            return _projectInfoService.Insert(model).Success();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Edit([FromBody]ProjectInfoEditDto model)
        {
            return _projectInfoService.Update(model).Success();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<ProjectInfoEditDto>> GetList()
        {
            var res = _projectInfoService.GetList();
            return res.Clone<List<ProjectInfoEditDto>>().Success();
        }

        /// <summary>
        /// 获取指定项目
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<ProjectInfoDto> Get([FromUri]int id)
        {
            return _projectInfoService.GetById(id).Success();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _projectInfoService.Deletes(ids).Success();
        }
    }
}