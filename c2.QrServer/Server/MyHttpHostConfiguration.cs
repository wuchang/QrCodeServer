using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace c2.QrServer
{
    class MyHttpHostConfiguration : HttpSelfHostConfiguration
    {
        public MyHttpHostConfiguration(string baseAddress)
            : base(baseAddress)
        {
            ConfigRoutes();
            CinfigFilters();

            //this.Formatters.JsonFormatter.SupportedMediaTypes
            //    .Add(new MediaTypeHeaderValue("application/json"));

        }

        private void CinfigFilters()
        {
            //throw new NotImplementedException();
            //this.Filters.Add(new RequestLogFilter());
            //this.Filters.Add(new MyFilterAttribute());
        }

        private void ConfigRoutes()
        {
            Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "{controller}/{action}",
                 defaults: new { action = "index" }
            );
        }

    }
}
