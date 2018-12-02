using ClothingSystem.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ClothingSystem.Dto.Enum;
using ClothingSystem.Dto.Model;
using ClothingSystem.Dto;
using ClothingSystem.Common;

namespace ClothingSystem.DAL.Impl
{
    public class AdministratorDal : BaseDal, IAdministratorDal
    {
        public AdministratorDal(AuthUserDto user) : base(user)
        {
        }

        public AdministratorDto GetByNameAndPwd(string adminName, string adminPwd)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<AdministratorDto>("select * from administrator where adminName=@adminName and adminPwd=@adminPwd and isdel=0", new { adminName, adminPwd });
            });
        }

        public AdministratorDto GetByName(string adminName)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<AdministratorDto>("select * from administrator where adminName=@adminName and isdel=0", new { adminName });
            });
        }

        public AdministratorDto GetById(int id)
        {
            return Connection(connection =>
            {
                return connection.QueryFirstOrDefault<AdministratorDto>("select * from administrator where id=@id and isdel=0", new { id });
            });
        }

        public List<AdministratorDto> GetList()
        {
            return Connection(connection =>
            {
                return connection.Query<AdministratorDto>("select * from administrator where isdel=0").ToList();
            });
        }

        public int Insert(AdministratorDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into administrator(AdminName,AdminPwd,CreateTime,LastLoginTime,LastLoginIp) output  inserted.id values (@AdminName,@AdminPwd,@CreateTime,@LastLoginTime,@LastLoginIp)";
                return connection.Execute(sql, model);
            });
        }

        public int Update(int id, DateTime lastLoginTime, string lastLoginIp)
        {
            return Connection(connection =>
            {
                var sql = "update administrator set lastLoginTime=@lastLoginTime,lastLoginIp=@lastLoginIp where id=@id";
                return connection.Execute(sql, new { id, lastLoginTime, lastLoginIp });
            });
        }

        public int Update(int id, string adminPwd)
        {
            return Connection(connection =>
            {
                var sql = "update administrator set adminPwd=@adminPwd where id=@id";
                return connection.Execute(sql, new { id, adminPwd });
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("administrator", ids);
        }
    }
}