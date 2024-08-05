using Microsoft.AspNetCore.Mvc;
using Wallet.BLL.Logic.Contracts.Users;
using Wallet.BLL.Logic.Users;
using Wallet.Common.Entities.User.DB;
using Wallet.Common.Entities.User.InputModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _userLogic.Get();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task PostAsync([FromBody] UserCreateInputModel user)
        {
            await _userLogic.CreateUserAsync(user);
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userLogic.Get(id);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
