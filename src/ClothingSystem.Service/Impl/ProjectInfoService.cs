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
    public class ProjectInfoService : BaseService, IProjectInfoService
    {
        private readonly IProjectInfoDal _projectInfoDal;

        public ProjectInfoService(AuthUserDto user) : base(user)
        {
            _projectInfoDal = new ProjectInfoDal(user);
        }

        public bool Insert(ProjectInfoAddDto model)
        {
            Verify(model);

            var info = model.Clone<ProjectInfoDto>();
            var nameModel = _projectInfoDal.GetByTitle(info.Title);
            if (nameModel != null)
                Exception("Insert.Title", "名称已存在");
            return _projectInfoDal.Insert(info) > 0;
        }

        public bool Update(ProjectInfoEditDto model)
        {
            Verify(model);

            var nameModel = _projectInfoDal.GetByTitle(model.Title);
            if (nameModel != null && nameModel.Id != model.Id)
                Exception("Update.Title", "名称已存在");

            return _projectInfoDal.Update(model) > 0;
        }

        private void Verify(ProjectInfoAddDto model)
        {
            AdminVerify(model, "Verify");

            if (string.IsNullOrEmpty(model.Title))
                Exception("Verify.Title", "项目名称不能为空");
        }

        public List<ProjectInfoDto> GetList()
        {
            AdminVerify(0, "GetList");
            return _projectInfoDal.GetList();
        }

        public bool Deletes(params int[] ids)
        {
            AdminVerify(ids, "Deletes");

            if (ids == null || ids.Length < 1)
                return true;
            return _projectInfoDal.Deletes(ids) > 0;
        }

        public ProjectInfoDto GetById(int id)
        {
            AdminVerify(id, "GetById");
            return _projectInfoDal.GetById(id);
        }
    }
}
