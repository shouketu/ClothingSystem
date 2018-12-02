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

    public class GroupInfoDal : BaseDal, IGroupInfoDal
    {
        public GroupInfoDal(AuthUserDto user) : base(user)
        {

        }

        public int Update(GroupInfoEditDto model)
        {
            return Connection(connection =>
            {
                var sql = "update GroupInfo set Title=@Title,ProjectId=@ProjectId where Id=@Id";
                return connection.Execute(sql, model);
            });
        }

        public int Insert(GroupInfoDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into GroupInfo(Title,ProjectId,AdminId,AdminName,CreateTime) output inserted.id values (@Title,@ProjectId,@AdminId,@AdminName,@CreateTime)";
                model.AdminId = _user.UserId;
                model.AdminName = _user.UserName;
                model.CreateTime = DateTime.Now;
                return connection.Execute(sql, model);
            });
        }

        public List<GroupInfoDto> GetList()
        {
            return Connection(connection =>
            {
                return connection.Query<GroupInfoDto>("select * from GroupInfo where isdel=0").ToList();
            });
        }

        public GroupInfoDto GetById(int id)
        {
            return Connection(connection =>
            {
                var where = " where id=@id and isdel=0";
                var param = new { id };
                var sql = $"select * from GroupInfo {where}";
                return connection.QueryFirstOrDefault<GroupInfoDto>(sql, param);
            });
        }

        public GroupInfoDto GetByTitle(string title)
        {
            return Connection(connection =>
            {
                var where = " where title=@title and isdel=0";
                var param = new { title };
                var sql = $"select * from GroupInfo {where}";
                return connection.QueryFirstOrDefault<GroupInfoDto>(sql, param);
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("GroupInfo", ids);
        }
    }
}
