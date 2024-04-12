using Microsoft.AspNetCore.Mvc;

namespace clashNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost(Name = "login")]
        public int login(string user, string password)
        {
            bool exists = Globals.users.TryGetValue(user, out string? hashedPassword);
            if (exists && hashedPassword == Globals.HashPassword(password))
            {
                return 200;
            }
            return 401;
        }
    }
}
