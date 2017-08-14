namespace UAC.Services.Api
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    using System.Web.Mvc;
    using Gimme;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Collection.RegisterAsFactoryWithName<IDbConnection, SqlConnection>("quality", System.Configuration.ConfigurationManager.ConnectionStrings["quality"].ConnectionString);
        }
    }
}
