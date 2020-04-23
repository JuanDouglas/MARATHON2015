using System;
using System.Linq;
using System.Web.Http;

namespace Marathon.API.Controllers
{
    public class LoginController : ApiController
    {
        Models.MarathonDBEntities db = new Models.MarathonDBEntities();
        // GET: api/Login
        public IHttpActionResult Get(string email, string password)
        {
            var result = db.User.FirstOrDefault(item => item.Email == email);
            if (result != null)
            {
                if (result.Password == password)
                {
                    Guid guid = Guid.NewGuid();
                    Models.ActiveLogins.Add(new Models.TokenSys(guid, email, password));
                    return Ok(new Models.TokenUser(guid, DateTime.Now));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Get(string token)
        {
            try
            {
                var tokenGuid = Guid.Parse(token);
                var testToken = Models.ActiveLogins.ActiveTokens.FirstOrDefault(item => item.TokenGuid == tokenGuid);
                var now = DateTime.Now;
                var TimeNow = new TimeSpan(now.Hour, now.Minute, now.Second);
                var Token_life_time = TimeNow.Subtract(testToken.TokenGeneratedDate);
                var Remaining_token_time = new TimeSpan(0, 5, 0).Subtract(Token_life_time);
                return Ok(new { Token_life_time, Remaining_token_time });
            }
            catch (System.FormatException)
            {
                return BadRequest("The token format is invalid");
            }
            catch (System.NullReferenceException)
            {
                return BadRequest("This token is invalid or has already expired");
            }
        }
    }
}

