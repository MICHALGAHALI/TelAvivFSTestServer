using exHomeTest_server.helper;
using exHomeTest_server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace exHomeTest_server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// keep all data the user entered to a json file 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/saveEnteredUser")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage saveEnteredUser()
        {
            string jsonUser = HttpContext.Current.Request.Params.Get("locations");
            try
            {
                Location[] loginDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<Location[]>(jsonUser);

                ValidationContext vc = new ValidationContext(loginDetails);
                ICollection<ValidationResult> results = new List<ValidationResult>(); // Will contain the results of the validation
                bool isValid = Validator.TryValidateObject(loginDetails, vc, results, true);
                if (isValid)
                {
                    DateTime td = new DateTime();
                    td = DateTime.Now;
                    String tds = td.Year + "_" + td.Month + "_" + td.Day + " T " + td.Hour + "_" + td.Minute + "_" + td.Second + "_" + td.Millisecond;
                    ConvertJsonToObject.SaveJson<Location[]>(@"Json\enteredUser_" + tds + ".json", loginDetails);
                    return Request.CreateResponse(HttpStatusCode.OK,"save succefuly");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, results);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
