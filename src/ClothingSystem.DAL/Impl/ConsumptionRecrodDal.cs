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
    /// <summary>
    /// 消费记录
    /// </summary>
    public class ConsumptionRecrodDal : BaseDal, IConsumptionRecrodDal
    {
        public ConsumptionRecrodDal(AuthUserDto user) : base(user)
        {

        }

        public int Update(ConsumptionRecrodEditDto model)
        {
            return Connection(connection =>
            {
                var sql = "update ConsumptionRecrod set CustomerInfoId=@CustomerInfoId,AddTime=@AddTime,Amount=@Amount,Remark=@Remark where Id=@Id";
                return connection.Execute(sql, model);
            });
        }

        public int Insert(ConsumptionRecrodDto model)
        {
            return Connection(connection =>
            {
                var sql = "insert into ConsumptionRecrod(CustomerInfoId,AddTime,Amount,Remark,CreateId,CreateName,CreateType,CreateTime) output  inserted.id values (@CustomerInfoId,@AddTime,@Amount,@Remark,@CreateId,@CreateName,@CreateType,@CreateTime)";
                model.CreateId = _user.UserId;
                model.CreateName = _user.UserName;
                model.CreateType = (Dto.Enum.UserTypeEnum)((int)_user.UserType);
                model.CreateTime = DateTime.Now;
                return connection.Execute(sql, model);
            });
        }

        public PageResult<ConsumptionRecrodDto> SearchPage(ConsumptionRecrodSearchDto par)
        {
            var where = "where isdel=0";
            if(par.CustomerInfoId.HasValue)
                where += " and CustomerInfoId=" + par.CustomerInfoId.Value;
            var order = "order by addtime desc";
            return SearchPage<ConsumptionRecrodDto>(par, where, order, "ConsumptionRecrod");
        }

        public ConsumptionRecrodDto GetById(int id)
        {
            return Connection(connection =>
            {
                var where = " where id=@id and isdel=0";
                var param = new { id };
                var sql = $"select * from ConsumptionRecrod {where}";
                return connection.QueryFirstOrDefault<ConsumptionRecrodDto>(sql, param);
            });
        }

        public int Deletes(params int[] ids)
        {
            return Deletes("ConsumptionRecrod", ids);
        }
    }
}
