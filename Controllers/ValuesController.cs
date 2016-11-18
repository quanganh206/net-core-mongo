using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using testmongo.Models;

namespace testmongo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DataAccess _dataAccess;

        public ValuesController() {
            _dataAccess = new DataAccess();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dataAccess.GetProducts();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
