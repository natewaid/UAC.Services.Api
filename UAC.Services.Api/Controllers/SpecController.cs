namespace UAC.Services.Api.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Http;
    using Flash;

    public class SpecController : ApiController
    {
        internal class Spec
        {
            public string Name { get; set; }
        }

        public IEnumerable<string> Get()
        {
            return Flash.List<Spec>(Gimme.Collection.Locate<IDbConnection>("quality"), "quality.specs").Select(s => s.Name);
        }
    }
}
