using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppApi48.Attributes;
using WebAppApi48.Services;

namespace WebAppApi48
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Init()
        {
            EndRequest -= WebApiApplication_EndRequest;
            EndRequest += WebApiApplication_EndRequest;
        }

        private void WebApiApplication_EndRequest(object sender, EventArgs e)
        {
            try
            {

                string absoluteURI = Request?.UrlReferrer?.AbsoluteUri;
                if(!string.IsNullOrWhiteSpace(absoluteURI))
                    this.Response?.AddHeader("Access-Control-Allow-Origin", absoluteURI.Remove(absoluteURI.Length-1) ?? "*");
                if (this.Request.HttpMethod == "OPTIONS")
                    this.Response.StatusCode = 200;
                if (this.Response.Headers["Allow"] != null)
                    this.Response.Headers.Add("Access-Control-Allow-Methods", this.Response.Headers["Allow"]);
                if (this.Response.Headers["Allow"] != null)
                {
                    this.Response.Headers.Add("Access-Control-Allow-Headers", string.Concat( HeadersConstants.UserID , "," , HeadersConstants.Password, ",", HeadersConstants.ContentType, ",", "Auth-Token", ",", "auth-token" ));
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
