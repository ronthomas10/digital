using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ronmi9digital
{

   
    public static class WebApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            
            config.EnableCors();

            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "service", id = RouteParameter.Optional }
            );
        }
    }
}
