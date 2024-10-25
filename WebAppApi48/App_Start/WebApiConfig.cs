using System.Web.Http;
using DataAccessLayer.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace WebAppApi48
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData
            
            config.Select().Expand().Filter().OrderBy().Count().MaxTop(null);
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ShoppingItems>("ShoppingItems");
            var edmModel = builder.GetEdmModel();
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",                
                model: edmModel);                
        }
    }
}
