﻿using ClothingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingSystem.Web.WebPage
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected UserTypeEnum _type;
        protected AuthUserDto _user;
        public BasePage(UserTypeEnum type)
        {
            _type = type;
            this.Init += BasePage_Init;
        }

        private void BasePage_Init(object sender, EventArgs e)
        {
            if (_type == UserTypeEnum.UserInfo)
            {
                _user = ContextHelper.GetByUserCookieKey();
                if (_user == null)
                    Redirect("/web/userlogin.aspx");   // 用户
            }
            else
            {
                _user = ContextHelper.GetByAdminCookieKey();
                if (_user == null)
                    Redirect("/webadmin/adminlogin.aspx");   // 管理员
            }

            (Master as MasterBase).SetUserType(_type);
            (Master as MasterBase).SetAuthUser(_user);
        }

        protected void Redirect(string url)
        {
            Response.Redirect(url);
        }
    }
}