using ClothingSystem.Web.App_Start;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ClothingSystem.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //使用swagger
            config.EnableSwagger("docs/{apiVersion}", c =>
            {
                c.SingleApiVersion("v1", "ClothingSystem").Description("服装系统");
                c.IncludeXmlComments(GetXmlCommentsPath("ClothingSystem.Web.XML"));

                c.BasicAuth("basic")
                    .Description("Basic HTTP Authentication");

            }).EnableSwaggerUi(c => {
            });

            // 授权验证
            config.MessageHandlers.Add(new AuthenticationMessageHandler());
            config.Filters.Add(new CSAuthAttribute());

            // 异常处理
            config.Services.Replace(typeof(IExceptionHandler), new ExceptionHandle());
        }

        private static string GetXmlCommentsPath(string filename)
        {
            return string.Format(@"{0}\bin\{1}", System.AppDomain.CurrentDomain.BaseDirectory, filename);
        }
    }
}
