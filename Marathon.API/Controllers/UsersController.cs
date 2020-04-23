using Marathon.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Marathon.API.Controllers
{
    public class UsersController : ApiController
    {
        private MarathonDBEntities db = new MarathonDBEntities();

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
                        list.Add(new UserModel(item));
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
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string token, string password)
        {
            try
            {
                var userEmail = ActiveLogins.ActiveTokens.FirstOrDefault(item => item.TokenGuid == Guid.Parse(token)).Email;
                User user = db.User.FirstOrDefault(usert => usert.Email == userEmail);
                if (user == null)
                {
                    return NotFound();
                }
                else if (user.Password != password)
                {
                    return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "this password is incorrect"));
                }
                var Role = new RoleModel(user.Role);
                var User = new UserModel(user);
                return Ok(new { User, Role });
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

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string token, User userput, string password)
        {
            try
            {
                var userEmail = ActiveLogins.ActiveTokens.FirstOrDefault(item => item.TokenGuid == Guid.Parse(token)).Email;
                User user = db.User.FirstOrDefault(usert => usert.Email == userEmail);
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
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userput.Email))
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
            catch (System.FormatException)
            {
                return BadRequest("The token format is invalid");
            }
            catch (System.NullReferenceException)
            {
                return BadRequest("This token is invalid or has already expired");
            }

        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            user.Password = "this value is private";
            return CreatedAtRoute("My", new { user.Email }, new UserModel(user));
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(string token, string password)
        {
            try
            {
                var userEmail = ActiveLogins.ActiveTokens.FirstOrDefault(item => item.TokenGuid == Guid.Parse(token)).Email;
                User user = db.User.FirstOrDefault(usert => usert.Email == userEmail);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.Password != password)
                {
                    return Unauthorized(new System.Net.Http.Headers.AuthenticationHeaderValue("Help", "this password is incorrect"));
                }

                db.User.Remove(user);
                db.SaveChanges();
                return Ok("This user has been deleted");
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.User.Count(e => e.Email == id) > 0;
        }
    }
}