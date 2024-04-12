using Microsoft.AspNetCore.Mvc;

namespace clashNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        [HttpPost(Name = "signup")]
        public int signup(string user, string password)
        {
            if (Globals.users.ContainsKey(user))
            {
                return 401;
            }
            System.Diagnostics.Debug.WriteLine(Globals.users.ContainsKey(user));
            Globals.users.Add(user, Globals.HashPassword(password));
            System.Diagnostics.Debug.WriteLine(Globals.users.ContainsKey(user));
            return 200;
        }
    }
}
