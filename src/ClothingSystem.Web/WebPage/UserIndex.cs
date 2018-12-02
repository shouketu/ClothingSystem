using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothingSystem.Common;

namespace ClothingSystem.Web.WebPage
{
    public partial class UserIndex : BasePage
    {
        public UserIndex() : base(UserTypeEnum.UserInfo)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}