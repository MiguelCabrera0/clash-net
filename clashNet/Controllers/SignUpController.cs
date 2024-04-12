using Microsoft.AspNetCore.Mvc;

namespace clashNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        [HttpPost(Name = "signup")]
        public int signup([FromBody] UserData userData)
        {
            if (Globals.users.ContainsKey(userData.user))
            {
                return 401;
            }
            System.Diagnostics.Debug.WriteLine(Globals.users.ContainsKey(userData.user));
            Globals.users.Add(userData.user, Globals.HashPassword(userData.password));
            System.Diagnostics.Debug.WriteLine(Globals.users.ContainsKey(userData.user));
            return 200;
        }
    }
}
