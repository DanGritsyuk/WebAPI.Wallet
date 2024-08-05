using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserV2Controller : ControllerBase
    {
        // GET: api/<UserV2Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserV2Controller>/5
        [HttpGet]
        [Route("byName/")]
        public string Get([FromQuery] string name)
        {
            return "value";
        }

        // POST api/<UserV2Controller>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            Console.WriteLine(value.Email);
        }

        // PUT api/<UserV2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserV2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
