using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new { Name = "Oleg"},
                new { Name = " Ivan"}
            };

            return Ok(users);
        }
    }
}
