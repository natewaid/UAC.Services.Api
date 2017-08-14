namespace UAC.Services.Api.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Flash;
    using System;

    public class AlloysController : ApiController
    {
        internal class SimpleString
        {
            public string ScalarString { get; set; }
        }

        public IHttpActionResult Get()
        {
            try
            {
                var alloys = Flash.List<SimpleString>(Gimme.Collection.Locate<IDbConnection>("quality"), "quality.alloys").Select(s => s.ScalarString);

                return Ok(alloys);
            }
            catch (Exception)
            {
                return InternalServerError();                
            }

            //return Flash.List<SimpleString>(Gimme.Collection.Locate<IDbConnection>("quality"), "quality.alloys").Select(s => s.ScalarString);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var alloy = Flash.List<SimpleString>(Gimme.Collection.Locate<IDbConnection>("quality"), "quality.alloys").Select(s => s.ScalarString).Where(s => s.Equals(id));

                return Ok(alloy);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] object obj)
        {
            // [FromBody] indicates that the API should read the contents of the request data and bind it to the complex type object being passed
            // [FromUri] indicates that the API should read the contents of the url parameters and bind them to the complex type object being passed

            try
            {
                if (obj == null)
                {
                    return BadRequest(); // status code 400
                }

                // do something, usually a post is used to create a resource
                // if action is successful, return Created(), status code 201

                return Created<object>($"{Request.RequestUri}/{"some id"}", obj);
            }
            catch (Exception)
            {
                return InternalServerError(); // status code 500
            }
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] object obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest(); 
                }

                // do something, usually a put is used to update all fields of an object

                // if action is successful, return Ok()

                // if the resource is not found, return NotFound() status code 404

                return Ok(obj);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] object obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest();
                }

                // do something, usually a patch is used to update only select field(s) of an object

                // if action is successful, return Ok()

                // if the resource is not found, return NotFound()

                // for a patch request, the data being sent must be a set of operations declared in json format:
                /*
                  original:
                    {
                        "baz": "qux",
                        "foo": "bar"
                    }

                    patch:
                    [
                      { "op": "replace", "path": "/baz", "value": "boo" },
                      { "op": "add", "path": "/hello", "value": ["world"] },
                      { "op": "remove", "path": "/foo"}
                    ]

                    result:
                    {
                        "baz": "boo",
                        "hello": "world"
                    }

                    other operations:  move, copy, test
                */

                return Ok(obj);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                // do something, obviously this is used to delete an object

                // if the delete is successful, return NoContent

                // if the object is not found, return NotFound

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
            
    }
}
