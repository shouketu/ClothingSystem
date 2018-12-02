using ClothingSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingSystem.Dto.Model;
using ClothingSystem.DAL.Interface;
using ClothingSystem.DAL.Impl;
using ClothingSystem.Common;
using ClothingSystem.Dto.Page;
using ClothingSystem.Dto;

namespace ClothingSystem.Service.Impl
{
    public class CustomerInfoService : BaseService, ICustomerInfoService
    {
        private readonly ICustomerInfoDal _customerInfoDal;
        private readonly IUserInfoService _userInfoService;

        public CustomerInfoService(AuthUserDto user) : base(user)
        {
            _customerInfoDal = new CustomerInfoDal(user);
            _userInfoService = new UserInfoService(user);
        }
        public bool Insert(CustomerInfoAddDto model)
        {
            if (model == null)
                Exception("Insert.model", "参数不能为空");
            //int createId = 0;
            //string createName = null;
            //if (model.CreateType == Dto.Enum.UserTypeEnum.UserInfo)
            //{ 
            //    var user = _userInfoService.GetBySession();
            //    if (user == null)
            //        return false;
            //    createId = user.Id;
            //    createName = user.UserName;
            //}
            //else
            //{
            //    // todo
            //}
            //var info = model.Clone<CustomerInfoDto>();
            //info.CreateTime = DateTime.Now;
            //info.CreateId = createId;
            //info.CreateName = createName;
            var info = model.Clone<CustomerInfoDto>();
            return _customerInfoDal.Insert(info) > 0;
        }

        public bool Update(CustomerInfoEditDto model)
        {
            if (model == null)
                Exception("Update.model", "参数不能为空");
            return _customerInfoDal.Update(model) > 0;
        }

        public PageResult<CustomerInfoDto> SearchPage(CustomerSearchDto search)
        {
            //var user = _userInfoService.GetBySession();
            //if (user == null)
            //    user = new UserInfoDto() { };
            // return new PageResult<CustomerInfoDto>();
            search = search ?? new CustomerSearchDto();
            search.PageSize = search.PageSize < 1 ? 50 : search.PageSize;
            search.PageIndex = search.PageIndex < 1 ? 1 : search.PageIndex;
            //search.UserId = user.Id;
            return _customerInfoDal.SearchPage(search);
        }

        public bool Deletes(params int[] ids)
        {
            if (ids == null || ids.Length < 1)
                return true;
            return _customerInfoDal.Deletes(ids) > 0;
        }
    }
}
