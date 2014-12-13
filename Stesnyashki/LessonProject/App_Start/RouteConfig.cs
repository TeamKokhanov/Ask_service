using Stesnyashki.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using  Microsoft.Web.WebPages.OAuth;

namespace Stesnyashki
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SHome", action = "Index", id = UrlParameter.Optional }
            );

            OAuthWebSecurity.RegisterClient(
       client: new VKontakteAuthenticationClient(
              "4649158", "VqQe594IUCLxZb9gQ09B"),
       displayName: "ВКонтакте", // надпись на кнопке
       extraData: null);

        }
    }
}