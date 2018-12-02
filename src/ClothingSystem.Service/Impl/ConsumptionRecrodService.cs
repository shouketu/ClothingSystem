using ClothingSystem.Common;
using ClothingSystem.DAL.Impl;
using ClothingSystem.DAL.Interface;
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
    public class ConsumptionRecrodService : BaseService, IConsumptionRecrodService
    {
        private readonly IConsumptionRecrodDal _consumptionRecrodDal;
        private readonly IUserInfoService _userInfoService;

        public ConsumptionRecrodService(AuthUserDto user) : base(user)
        {
            _consumptionRecrodDal = new ConsumptionRecrodDal(user);
            _userInfoService = new UserInfoService(user);
        }
        public bool Insert(ConsumptionRecrodAddDto model)
        {
            if (model == null)
                Exception("Insert.model", "参数不能为空");

            var info = model.Clone<ConsumptionRecrodDto>();
            return _consumptionRecrodDal.Insert(info) > 0;
        }

        public bool Update(ConsumptionRecrodEditDto model)
        {
            if (model == null)
                Exception("Update.model", "参数不能为空");
            return _consumptionRecrodDal.Update(model) > 0;
        }

        public PageResult<ConsumptionRecrodDto> SearchPage(ConsumptionRecrodSearchDto search)
        {
            search = search ?? new ConsumptionRecrodSearchDto();
            search.PageSize = search.PageSize < 1 ? 50 : search.PageSize;
            search.PageIndex = search.PageIndex < 1 ? 1 : search.PageIndex;
            return _consumptionRecrodDal.SearchPage(search);
        }

        public ConsumptionRecrodDto GetById(int id)
        {
            return _consumptionRecrodDal.GetById(id);
        }

        public bool Deletes(params int[] ids)
        {
            if (ids == null || ids.Length < 1)
                return true;
            return _consumptionRecrodDal.Deletes(ids) > 0;
        }
    }
}
