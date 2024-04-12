using Microsoft.AspNetCore.Mvc;

namespace clashNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost(Name = "login")]
        public int login([FromBody] UserData userData)
        {
            bool exists = Globals.users.TryGetValue(userData.user, out string? hashedPassword);
            if (exists && hashedPassword == Globals.HashPassword(userData.password))
            {
                return 200;
            }
            return 401;
        }
    }
}
