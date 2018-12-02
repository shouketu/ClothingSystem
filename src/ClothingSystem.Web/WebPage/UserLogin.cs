using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothingSystem.Common;

namespace ClothingSystem.Web.WebPage
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = ContextHelper.GetByUserCookieKey();
            if (user != null)
                Response.Redirect("/web/userindex.aspx");  // 跳回首页
        }
    }
}