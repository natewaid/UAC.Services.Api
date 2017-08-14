namespace UAC.Services.Api.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Http;
    using Flash;

    public class TemperController : ApiController
    {
        internal class SimpleString
        {
            public string ScalarString { get; set; }
        }

        public IEnumerable<string> Get()
        {
            return Flash.List<SimpleString>(Gimme.Collection.Locate<IDbConnection>("quality"), "quality.tempers").Select(s => s.ScalarString);
        }
    }
}
