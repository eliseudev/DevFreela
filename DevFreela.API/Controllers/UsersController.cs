using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController(ExempleClass exemple)
        {

        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel model)
        {
            return CreatedAtAction(nameof(GetById), new { Id = 1 }, model);
        }

        //api/users/1/login
        [HttpPut("{Id}/login")]
        public IActionResult Login(int Id, [FromBody] LoginModel model)
        {
            return NoContent();
        }
    }
}
