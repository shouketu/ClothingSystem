using ClothingSystem.Common;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto;
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
    public class UserInfoDal : BaseDal, IUserInfoDal
    {
        public UserInfoDal(AuthUserDto user) : base(user)
        {

        }

        public UserInfoDto GetByNameAndPwd(string userName, string userPwd)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<UserInfoDto>("select * from userinfo where userName=@userName and userPwd=@userPwd and isdel=0", new { userName, userPwd });
            });
        }

        public UserInfoFullDto GetById(int id)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<UserInfoFullDto>("select * from userinfo where id=@id and isdel=0", new { id });
            });
        }

        public List<UserInfoFullDto> GetList(params int[] ids)
        {
            return Connection(connection =>
            {
                var where = "where isdel=0";
                if (ids != null && ids.Length > 0)
                    where += $" and id in ({string.Join(",", ids)})";
                return connection.Query<UserInfoFullDto>("select * from userinfo " + where).ToList();
            });
        }

        public PageResult<UserInfoFullDto> SearchPage(UserInfoSearchDto search)
        {
            var where = " where isdel=0";
            if (search.GroupId.HasValue)
                where += " and GroupId like @GroupId";
            if (!string.IsNullOrEmpty(search.UserName))
                where += " and UserName like @UserName";
            var order = "order by id desc";
            var param = new { Name = $"%{search.UserName}%", search.GroupId };
            return SearchPage<UserInfoFullDto>(search, where, order, "userinfo", param: param);
        }

        public int Insert(UserInfoDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into userinfo(UserName,UserPwd,CreateTime,Mobile,GroupId,AdminId,AdminName) output  inserted.id values (@UserName,@UserPwd,@CreateTime,@Mobile,@GroupId,@AdminId,@AdminName)";
                model.AdminId = _user.UserId;
                model.AdminName = _user.UserName;
                model.CreateTime = DateTime.Now;
                return connection.ExecuteScalar<int>(sql, model);
            });
        }

        public int Update(UserInfoEditDto model)
        {
            return Connection(connection =>
            {
                var sql = "update userinfo set UserName=@UserName,Mobile=@Mobile,GroupId=@GroupId where Id=@Id";
                return connection.Execute(sql, model);
            });
        }

        public int Update(int id, string userPwd)
        {
            return Connection(connection =>
            {
                var sql = "update userinfo set userPwd=@userPwd where id=@id";
                return connection.Execute(sql, new { id, userPwd });
            });
        }

        public UserInfoDto GetByName(string userName)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<UserInfoDto>("select * from userinfo where userName=@userName and isdel=0", new { userName });
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("userinfo", ids);
        }
    }
}
