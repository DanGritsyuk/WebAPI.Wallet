using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        public static List<User> users = new List<User> { new User { Name = "Bob", Age = 25 }, new User { Name = "Tom", Age = 24 } };

        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            //var user = users.FirstOrDefault(u => u.Name == name);
            return new User();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
