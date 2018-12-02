using ClothingSystem.Common;
using ClothingSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ClothingSystem.Web.App_Start
{
    internal class AuthenticationMessageHandler : DelegatingHandler
    {
        public AuthenticationMessageHandler()
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthUserDto user = null;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization != null)
            {
                if (authorization.Scheme == "Basic" && !string.IsNullOrEmpty(authorization.Parameter))
                {
                    string auth = authorization.Parameter.Trim();
                    user = AuthUserCache.Get(auth) as AuthUserDto;
                }
            }

            GenericPrincipal genericPrincipal = new GenericPrincipal(new AuthUserIdentity(user), null);
            Thread.CurrentPrincipal = genericPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = genericPrincipal;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }

    /// <summary>
	/// 授权信息
	/// </summary>
	internal class AuthUserIdentity : ClaimsIdentity
    {
        private AuthUserDto _user;
        public AuthUserDto AuthUserInfo
        {
            [CompilerGenerated]
            get
            {
                return _user;
            }
        }
        public override bool IsAuthenticated
        {
            get
            {
                return this._user != null && this._user.UserId > 0;
            }
        }
        public AuthUserIdentity(AuthUserDto user)
        {
            _user = user;
        }
    }

    internal class CSAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return;

            if (actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return;

            if (!this.IsAuthorized(actionContext))
            {
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "无效的授权信息");
                //actionContext.Response = new HttpResponseMessage(HttpStatusCode.Redirect);
                //actionContext.Response.Headers.Location = new Uri("http://baidu.com.com");
            }
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity;
            if (identity != null && HttpContext.Current != null)
            {
                identity = HttpContext.Current.User.Identity;
            }
            return identity != null && identity.IsAuthenticated;
        }
    }
}