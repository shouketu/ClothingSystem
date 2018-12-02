using ClothingSystem.Common;
using ClothingSystem.Dto;
using ClothingSystem.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ClothingSystem.Web.Controllers
{
    public class BaseController : ApiController
    {
        protected AuthUserDto _user;

        public BaseController()
        {
            var userIdentity = HttpContext.Current.User.Identity as AuthUserIdentity;
            _user = userIdentity?.AuthUserInfo;
        }
    }
}