namespace UAC.Services.Api
{
    using Newtonsoft.Json.Serialization;
    using System.Linq;
    using System.Web.Http;
    using System.Net.Http.Headers;

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

            // removes specific application/xml formatter from the api call
            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // removes all xml formatters
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // add support for application/json-patch+json
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            // adds the text/html formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // adds indention to the returned json data
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // adds camel case to the field names in the json data
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // add caching - install CacheCow Server/Common Nuget
            config.MessageHandlers.Add(new CacheCow.Server.CachingHandler(config));
        }
    }
}
