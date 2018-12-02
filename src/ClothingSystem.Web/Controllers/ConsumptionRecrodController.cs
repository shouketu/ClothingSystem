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
    /// 消费记录
    /// </summary>
    public class ConsumptionRecrodController : BaseController
    {
        private readonly IConsumptionRecrodService _consumptionRecrodService;
        public ConsumptionRecrodController()
        {
            _consumptionRecrodService = new ConsumptionRecrodService(_user);
        }

        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]ConsumptionRecrodAddDto model)
        {
            return _consumptionRecrodService.Insert(model).Success();
        }

        /// <summary>
        /// 编辑消费记录
        /// </summary>
        /// <param name="model">对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Edit([FromBody]ConsumptionRecrodEditDto model)
        {
            return _consumptionRecrodService.Update(model).Success();
        }

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PageResult<ConsumptionRecrodEditDto>> SearchPage([FromBody]ConsumptionRecrodSearchDto search)
        {
            var res = _consumptionRecrodService.SearchPage(search);
            return res.Clone<PageResult<ConsumptionRecrodEditDto>>().Success();
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<ConsumptionRecrodEditDto> Get([FromUri]int id)
        {
            var res = _consumptionRecrodService.GetById(id);
            // return res.Success();
            return res.Clone<ConsumptionRecrodEditDto>().Success();
        }

        /// <summary>
        /// 删除消费记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _consumptionRecrodService.Deletes(ids).Success();
        }
    }
}