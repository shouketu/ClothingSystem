using ClothingSystem.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingSystem.Dto.Model;
using Dapper;
using ClothingSystem.Dto.Page;
using ClothingSystem.Dto;
using ClothingSystem.Common;

namespace ClothingSystem.DAL.Impl
{
    public class CustomerInfoDal : BaseDal, ICustomerInfoDal
    {
        public CustomerInfoDal(AuthUserDto user) : base(user)
        {

        }

        public int Update(CustomerInfoEditDto model)
        {
            return Connection(connection =>
            {
                var sql = "update CustomerInfo set Name=@Name,Mobile=@Mobile,QQ=@QQ,AuthAddress=@AuthAddress,PurchaseDiscount=@PurchaseDiscount,FirstPayment=@FirstPayment,ShipmentPayment=@ShipmentPayment,ContractManager=@ContractManager,JoinTime=@JoinTime,Remark=@Remark,GroupId=@GroupId,UserId=@UserId where Id=@Id";
                return connection.Execute(sql, model);
            });
        }

        public int Insert(CustomerInfoDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into CustomerInfo(CreateId,CreateName,CreateType,CreateTime,Name,Mobile,QQ,AuthAddress,PurchaseDiscount,FirstPayment,ShipmentPayment,ContractManager,JoinTime,Remark,GroupId,UserId) output  inserted.id values (@CreateId,@CreateName,@CreateType,@CreateTime,@Name,@Mobile,@QQ,@AuthAddress,@PurchaseDiscount,@FirstPayment,@ShipmentPayment,@ContractManager,@JoinTime,@Remark,@GroupId,@UserId)";
                model.CreateId = _user.UserId;
                model.CreateName = _user.UserName;
                model.CreateType = (Dto.Enum.UserTypeEnum)((int)_user.UserType);
                model.CreateTime = DateTime.Now;
                return connection.Execute(sql, model);
            });
        }

        public PageResult<CustomerInfoFullDto> SearchPage(CustomerSearchDto search)
        {
            var where = GetUserWhere();
            if (search.UserId.HasValue)
                where += " and UserId=@UserId";
            if (search.GroupId.HasValue)
                where += " and GroupId=@GroupId";
            if (!string.IsNullOrEmpty(search.Name))
                where += " and Name like @Name";
            var order = "order by jointime desc";
            var param = new { Name = $"%{search.Name}%", search.UserId, search.GroupId };
            return SearchPage<CustomerInfoFullDto>(search, where, order, "CustomerInfo", param: param);
            //return Connection(connection =>
            //{
            // var where = "where UserId=@UserId";
            //    if (!string.IsNullOrEmpty(search.Name))
            //        where += " and Name like @Name";
            //    var order = "order by jointime desc";
            //    var sql = $"select row_number() over({order}) as rn, * from CustomerInfo {where}";
            //    var param = new { Name = $"%{search.Name}%", search.UserId };
            //    var list = connection.Query<CustomerInfoDto>($"select * from ({sql}) as t where rn>={((search.PageIndex - 1) * search.PageSize)} and rn<={search.PageIndex * search.PageSize}", param);

            //    var total = connection.ExecuteScalar<long>($"select count(1) from CustomerInfo {where}", param);
            //    var pageCount = (long)Math.Ceiling(total * 1.0 / search.PageSize);

            //    return new PageResult<CustomerInfoDto>() { PageSize = search.PageSize, PageIndex = search.PageIndex, Items = list.ToList(),Total = total, PageCount = pageCount };   
            //});
        }

        public CustomerInfoFullDto GetById(int id)
        {
            return Connection(connection =>
            {
                var where = GetUserWhere();
                where += " and id=@id";
                var param = new { id, _user.UserId };
                var sql = $"select * from CustomerInfo {where}";
                return connection.QueryFirstOrDefault<CustomerInfoFullDto>(sql, param);
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("CustomerInfo", ids);
        }
    }
}
