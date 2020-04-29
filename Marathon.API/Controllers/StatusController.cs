using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marathon.API.Controllers
{
    public class StatusController : ApiController
    {
        static Data.MarathonSkillsEntities db = new Data.MarathonSkillsEntities();
        // GET api/<controller>
        public IHttpActionResult Get(bool log)
        {
            try
            {
                var user = new Data.User();
                user.Email = "test@test.test";
                user.Password = "Test.Testing";
                user.FirstName = "Test";
                var DataBaseName = db.Database.Connection.Database;
                var ConnectionState = db.Database.Connection.State.ToString();
                var ConnectionString = db.Database.Connection.ConnectionString;
                var Log = db.Database.Log;
                if (!log)
                    return Ok(new { DataBaseName, ConnectionState, ConnectionString, log });
                else
                    return Ok(new { DataBaseName, ConnectionState, ConnectionString, log, Log });
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        public IHttpActionResult Get()
        {
            return Get(false);
        }
    }
}