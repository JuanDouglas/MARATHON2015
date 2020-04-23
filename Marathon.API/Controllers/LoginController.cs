using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marathon.API.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IHttpActionResult Get(string email, string password)
        {
            var result = new Models.MarathonDBEntities().Users.FirstOrDefault(item => item.Email == email);
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
                var lifeTime = TimeNow.Subtract(testToken.TokenGeneratedDate);
                var text = "Token lifetime: ";
                return Ok(new { text, lifeTime });
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

