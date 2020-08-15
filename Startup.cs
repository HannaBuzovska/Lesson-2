using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using OWINWebApi;

[assembly: OwinStartup(typeof(WebApiOwin.Startup))]
namespace WebApiOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule), "OwinLogger: ");
            app.Use(typeof(WebApiModule));
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "{controller}");
            app.UseWebApi(config);
        }
    }
}
