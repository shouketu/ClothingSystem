using ClothingSystem.Common;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto.Model;
using ClothingSystem.Dto.Page;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL.Impl
{
    
    public class ProjectInfoDal : BaseDal, IProjectInfoDal
    {
        public ProjectInfoDal(AuthUserDto user) : base(user)
        {

        }

        public int Update(ProjectInfoEditDto model)
        {
            return Connection(connection =>
            {
                var sql = "update ProjectInfo set Title=@Title where Id=@Id";
                return connection.Execute(sql, model);
            });
        }

        public int Insert(ProjectInfoDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into ProjectInfo(Title,AdminId,AdminName,CreateTime) output inserted.id values (@Title,@AdminId,@AdminName,@CreateTime)";
                model.AdminId = _user.UserId;
                model.AdminName = _user.UserName;
                model.CreateTime = DateTime.Now;
                return connection.Execute(sql, model);
            });
        }

        public List<ProjectInfoDto> GetList()
        {
            return Connection(connection =>
            {
                return connection.Query<ProjectInfoDto>("select * from ProjectInfo where isdel=0").ToList();
            });
        }

        public ProjectInfoDto GetById(int id)
        {
            return Connection(connection =>
            {
                var where = " where id=@id and isdel=0";
                var param = new { id };
                var sql = $"select * from ProjectInfo {where}";
                return connection.QueryFirstOrDefault<ProjectInfoDto>(sql, param);
            });
        }

        public ProjectInfoDto GetByTitle(string title)
        {
            return Connection(connection =>
            {
                var where = " where title=@title and isdel=0";
                var param = new { title };
                var sql = $"select * from ProjectInfo {where}";
                return connection.QueryFirstOrDefault<ProjectInfoDto>(sql, param);
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("ProjectInfo", ids);
        }
    }
}
