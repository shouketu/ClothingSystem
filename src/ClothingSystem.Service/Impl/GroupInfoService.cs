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
    public class GroupInfoService : BaseService, IGroupInfoService
    {
        private readonly IGroupInfoDal _groupInfoDal;

        public GroupInfoService(AuthUserDto user) : base(user)
        {
            _groupInfoDal = new GroupInfoDal(user);
        }

        public bool Insert(GroupInfoAddDto model)
        {
            Verify(model);

            var info = model.Clone<GroupInfoDto>();
            var nameModel = _groupInfoDal.GetByTitle(info.Title);
            if (nameModel != null)
                Exception("Insert.Title", "名称已存在");
            return _groupInfoDal.Insert(info) > 0;
        }

        public bool Update(GroupInfoEditDto model)
        {
            Verify(model);

            var nameModel = _groupInfoDal.GetByTitle(model.Title);
            if (nameModel != null && nameModel.Id != model.Id)
                Exception("Update.Title", "名称已存在");

            return _groupInfoDal.Update(model) > 0;
        }

        private void Verify(GroupInfoAddDto model)
        {
            AdminVerify(model, "Verify");

            if (string.IsNullOrEmpty(model.Title))
                Exception("Verify.UserName", "用户名不能为空");
        }

        public List<GroupInfoDto> GetList()
        {
            AdminVerify(0, "GetList");
            return _groupInfoDal.GetList();
        }

        public bool Deletes(params int[] ids)
        {
            AdminVerify(ids, "Deletes");

            if (ids == null || ids.Length < 1)
                return true;
            return _groupInfoDal.Deletes(ids) > 0;
        }

        public GroupInfoDto GetById(int id)
        {
            AdminVerify(id, "GetById");
            return _groupInfoDal.GetById(id);
        }
    }
}
