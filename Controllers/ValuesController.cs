using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using AspNetCoreWebAPI.Helpers;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {            
            string resposne = await Http.Get("https://jsonplaceholder.typicode.com/users");
           
            return resposne;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Database database = new Database();

            var results = database.query("SELECT * FROM test.test_schema.test_table");

            return results.ToString();

        }

        // POST api/values
        [HttpPost]
        public async Task<string>Post([FromBody]string value)
        {
            var payload = new Dictionary<string, string>
            {
                {"foo", "bar"},
                {"fizz", "buzz"}  
            };

            string response = await Http.Post("https://jsonplaceholder.typicode.com/post", payload);

            return response;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
