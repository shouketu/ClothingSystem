using ClothingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingSystem.Web.WebPage
{
    public class AdminIndex: BasePage
    {
        public AdminIndex() : base(UserTypeEnum.Administrator)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}