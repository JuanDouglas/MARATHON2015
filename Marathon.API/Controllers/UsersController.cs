using Marathon.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Marathon.API.Controllers
{
    public class UsersController : ApiController
    {
        private Data.MarathonSkillsEntities db = new Data.MarathonSkillsEntities();

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "is area and inaccessible to your level"));
        }
        public IHttpActionResult GetUsers(string voceEUmIdiota)
        {
            try
            {
                if (voceEUmIdiota == "euSouODouglas")
                {
                    var list = new List<UserModel>();
                    foreach (var item in db.User.ToList())
                    {
                        list.Add(new UserModel(item,item.Role));
                    }
                    return Ok(list);
                }
                return null;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // GET: api/Users/5
        [ResponseType(typeof(Data.User))]
        public async Task<IHttpActionResult> GetUser(string token, string password)
        {
            try
            {
                var userEmail = ActiveLogins.GetToken(Guid.Parse(token));
                Data.User userDB = await db.User.FirstOrDefaultAsync(usert => usert.Email == userEmail.Email);
                if (userDB == null)
                {
                    return NotFound();
                }
                else if (userDB.Password != password)
                {
                    return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "this password is incorrect"));
                }
                if (userEmail.AcessLevel == Enums.LevelAcess.Application)
                {
                    var Role = new RoleModel(userDB.Role);
                    var User = new UserModel(userDB,userDB.Role);
                    return Ok(User);
                }
                else if (userEmail.AcessLevel == Enums.LevelAcess.User)
                {
                    return Ok(userDB);
                }
                    return Unauthorized();
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

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(string token, Data.User userput, string password)
        {
            try
            {
                var userEmail = ActiveLogins.GetToken(Guid.Parse(token)).Email;
                Data.User user = await db.User.FirstOrDefaultAsync(usert => usert.Email == userEmail);
                if (user == null)
                {
                    return NotFound();
                }
                else if (user.Password != password)
                {
                    return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "this password is incorrect"));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (user.Email != userput.Email)
                {
                    return BadRequest();
                }
                db.Entry(userput).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserExists(userput.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
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

        // POST: api/Users
        [ResponseType(typeof(Data.User))]
        public async Task<IHttpActionResult> PostUser(Data.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (await UserExists(user.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            user.Password = "this value is private";
            return CreatedAtRoute("My", new { user.Email }, new UserModel(user,user.Role));
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Data.User))]
        public async Task<IHttpActionResult> DeleteUser(string token, string password)
        {
            try
            {
                var userEmail = ActiveLogins.GetToken(Guid.Parse(token));

                Data.User user = db.User.FirstOrDefault(usert => usert.Email == userEmail.Email);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.Password != password)
                {
                    return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "this password is incorrect"));
                }
                if (userEmail.AcessLevel == Enums.LevelAcess.Restricted)
                {
                    return Unauthorized();
                }

                db.User.Remove(user);
                await db.SaveChangesAsync();
                return Ok("This user has been deleted");
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<bool> UserExists(string id)
        {
            return await db.User.CountAsync(e => e.Email == id) > 0;
        }
    }
}