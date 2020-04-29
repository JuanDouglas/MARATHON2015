using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marathon.API.Controllers
{
    public class LoginController : ApiController
    {
        Data.MarathonSkillsEntities db = new Data.MarathonSkillsEntities();
        // GET: api/Login
        public async Task<IHttpActionResult> Get(string email, string password)
        {
            var result = await db.User.FirstOrDefaultAsync(item => item.Email == email);
            if (result != null)
            {
                if (result.Password == password)
                {
                    Guid guid = Guid.NewGuid();
                    Models.ActiveLogins.Add(new Models.TokenSys(guid, email, password, Enums.LevelAcess.Application));
                    return Ok(new Models.TokenUser(guid, DateTime.Now));
                }
                else
                {
                    return Unauthorized();
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
                //var testToken = Models.ActiveLogins.ActiveTokens.FirstOrDefault(item => item.TokenGuid == tokenGuid);
                var testToken = Models.ActiveLogins.GetToken(tokenGuid);
                var now = DateTime.Now;
                var TimeNow = new TimeSpan(now.Hour, now.Minute, now.Second);
                
                
                var Token_life_time = TimeNow.Subtract(testToken.TokenGeneratedDate);
                var Remaing_token_time = Models.ActiveLogins.TokenInterval.Subtract(Token_life_time);
                var Acess_Level = testToken.AcessLevel;
                return Ok(new { Token_life_time, Acess_Level, Remaing_token_time });
            }
            catch (FormatException)
            {
                return BadRequest("The token format is invalid");
            }
            catch (NullReferenceException)
            {
                return BadRequest("This token is invalid or has already expired");
            }
        }
        public IHttpActionResult GetToken(string token, string password)
        {
            try
            {
                var tokenGuid = Guid.Parse(token);
                var testToken = Models.ActiveLogins.GetToken(tokenGuid);
                var now = DateTime.Now;
                var TimeNow = new TimeSpan(now.Hour, now.Minute, now.Second);
                var Token_life_time = TimeNow.Subtract(testToken.TokenGeneratedDate);
                var Remaining_token_time = new TimeSpan(0, 5, 0).Subtract(Token_life_time);
                if (testToken.Password == password)
                {
                    var New_token = Guid.NewGuid();
                    Models.ActiveLogins.Add(new Models.TokenSys(New_token, testToken.Email, password, Enums.LevelAcess.User));
                    return Ok(new { New_token, Remaining_token_time });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (FormatException)
            {
                return BadRequest("The token format is invalid");
            }
            catch (NullReferenceException)
            {
                return BadRequest("This token is invalid or has already expired");
            }
        }
    }
}

