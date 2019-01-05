using ClothingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingSystem.Web.WebPage
{
    public class MasterBase : System.Web.UI.MasterPage
    {
        protected UserTypeEnum _type;
        protected AuthUserDto _user;

        public void SetUserType(UserTypeEnum type)
        {
            _type = type;
        }

        public void SetAuthUser(AuthUserDto user)
        {
            _user = user;
        }
    }
}