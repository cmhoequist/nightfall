using Autofac;
using System.Linq;
using System.Web;
using System.Web.Http;
using Nightfall.Datastore;
using Autofac.Integration.WebApi;
using System.Reflection;
using Nightfall.Application.Interfaces;
using Nightfall.Datastore.QueryHandlers;

namespace Nightfall.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;

            var container = DependencyInjection.Bootstrap();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        protected void Application_BeginRequest()
        {
            WriteCorsHeader();
        }

        protected void WriteCorsHeader()
        {
            var allowedOrigins = System.Configuration.ConfigurationManager.AppSettings["CORS_Origins"];
            var allowedOriginList = allowedOrigins.Split(',').Select(i => i).ToList();

            HttpContext.Current.Response.Headers.Remove("Access-Control-Allow-Origin");
            HttpContext.Current.Response.Headers.Remove("Access-Control-Allow-Credentials");
            HttpContext.Current.Response.Headers.Remove("Access-Control-Allow-Methods");

            if (!allowedOrigins.Contains("*"))
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            }
            string currentOrigin;
            switch (HttpContext.Current.Request.HttpMethod)
            {
                case "OPTIONS":
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers["Origin"])){
                        currentOrigin = HttpContext.Current.Request.Headers["Origin"];
                        if (allowedOriginList.Contains(currentOrigin))
                        {
                            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", currentOrigin);
                        }
                    }

                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, PATCH, DELETE");
                    HttpContext.Current.Response.End();
                    break;
                default:
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers["Origin"]))
                    {
                        currentOrigin = HttpContext.Current.Request.Headers["Origin"];
                        if (allowedOriginList.Contains(currentOrigin))
                        {
                            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", currentOrigin);
                        }
                    }
                    break;
            }
        }
    }
}
