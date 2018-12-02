using ClothingSystem.Common;
using ClothingSystem.DAL.Interface;
using ClothingSystem.Dto;
using ClothingSystem.Dto.Model;
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
        public bool ExistByNameAndPwd(string userName, string userPwd)
        {
            return Connection(connection =>
            {
                return connection.ExecuteScalar<int>("select count(1) from userinfo where userName=@userName and userPwd=@userPwd", new { userName, userPwd }) > 0;
            });
        }

        public UserInfoDto GetByNameAndPwd(string userName, string userPwd)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<UserInfoDto>("select * from userinfo where userName=@userName and userPwd=@userPwd", new { userName, userPwd });
            });
        }

        public UserInfoDto GetById(int id)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<UserInfoDto>("select * from userinfo where id=@id", new { id });
            });
        }

        public List<UserInfoDto> GetList()
        {
            return Connection(connection =>
            {
                return connection.Query<UserInfoDto>("select * from userinfo").ToList();
            });
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
                return connection.QueryFirstOrDefault<UserInfoDto>("select * from userinfo where userName=@userName", new { userName });
            });
        }
    }
}
