using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingSystem.Web.WebPage
{
    public class AdminCustomerDetail : CustomerDetail
    {
        public AdminCustomerDetail() : base(Common.UserTypeEnum.Administrator)
        {

        }
    }
}