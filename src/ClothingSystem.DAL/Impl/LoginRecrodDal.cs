using ClothingSystem.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingSystem.Dto.Model;
using Dapper;
using ClothingSystem.Dto;
using ClothingSystem.Common;

namespace ClothingSystem.DAL.Impl
{
    public class LoginRecrodDal : BaseDal, ILoginRecrodDal
    {
        public LoginRecrodDal(AuthUserDto user) : base(user)
        {

        }

        public int Insert(LoginRecrodDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into loginrecrod(LoginTime,LoginIp,UserId,UserName,UserType) output  inserted.id values (@LoginTime,@LoginIp,@UserId,@UserName,@UserType)";
                return connection.ExecuteScalar<int>(sql, model);
            });
        }
    }
}
