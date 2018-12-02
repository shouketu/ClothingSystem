using ClothingSystem.Common;
using ClothingSystem.Dto;
using ClothingSystem.Dto.Page;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.DAL
{
    public class BaseDal
    {
        protected AuthUserDto _user;
        protected static string _connectionString = Tools.GetConnectionString("ConnectionString");

        public BaseDal(AuthUserDto user)
        {
            _user = user;
        }

        protected T Connection<T>(Func<IDbConnection, T> fun)
        {
            if (fun == null)
                return default(T);
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return fun(connection);
            }
        }
        
        protected void Connection(Action<IDbConnection> action)
        {
            if (action == null)
                return;
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                action(connection);
            }
        }

        protected PageResult<T> SearchPage<T>(PageParameter par, string where, string order, string table, string select = "*", object param = null)
        {
            return Connection(connection =>
            {
                var sql = $"select row_number() over({order}) as rn, {select} from {table} {where}";
                var start = (par.PageIndex - 1) * par.PageSize + 1;
                var end = par.PageIndex * par.PageSize;
                var list = connection.Query<T>($"select * from ({sql}) as t where rn>={start} and rn<={end}", param);

                var total = connection.ExecuteScalar<long>($"select count(1) from {table} {where}", param);
                var pageCount = (long)Math.Ceiling(total * 1.0 / par.PageSize);

                return new PageResult<T>() { PageSize = par.PageSize, PageIndex = par.PageIndex, Items = list.ToList(), Total = total, PageCount = pageCount };
            });
        }

        protected string GetUserWhere(bool isAddWhere = true)
        {
            string where = null;
            if (isAddWhere)
                where = " where";
            where += " isdel=0 ";
            if (_user.UserType ==  UserTypeEnum.UserInfo)
                where += " and UserId=" + _user.UserId;
            return where;
        }

        protected int Deletes(string table, params int[] ids)
        {
            return Connection(connection =>
            {
                var sql = $"update {table} set isdel=1 where id in ({string.Join(",", ids)})";
                return connection.Execute(sql);
            });
        }
    }
}
