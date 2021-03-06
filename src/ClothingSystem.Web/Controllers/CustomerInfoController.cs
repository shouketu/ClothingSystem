﻿using ClothingSystem.Common;
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
    /// 顾客信息
    /// </summary>
    public class CustomerInfoController : BaseController
    {
        private readonly ICustomerInfoService _customerInfoService;
        public CustomerInfoController()
        {
            _customerInfoService = new CustomerInfoService(_user);
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="model">顾客对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Add([FromBody]CustomerInfoAddDto model)
        {
            return _customerInfoService.Insert(model).Success();
        }

        /// <summary>
        /// 编辑顾客
        /// </summary>
        /// <param name="model">顾客对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Edit([FromBody]CustomerInfoEditDto model)
        {
            return _customerInfoService.Update(model).Success();
        }

        /// <summary>
        /// 搜索分页
        /// </summary>
        /// <param name="search">搜索对象</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PageResult<CustomerInfoFullDto>> SearchPage([FromBody]CustomerSearchDto search)
        {
            var res = _customerInfoService.SearchPage(search);
            return res.Success();
            // return res.Clone<PageResult<CustomerInfoEditDto>>().Success();
        }

        /// <summary>
        /// 根据Id获取顾客
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<CustomerInfoFullDto> Get(int id)
        {
            return _customerInfoService.GetById(id).Success();
        }

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Deletes(int[] ids)
        {
            return _customerInfoService.Deletes(ids).Success();
        }
    }
}