using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marathon.API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<Models.UserModel>> Get()
        {
            var list = await new Data.MarathonSkillsEntities().User.ToListAsync();
            var List = new List<Models.UserModel>();
            foreach (var item in list)
            {
                List.Add(new Models.UserModel(item,item.Role));
            }
            return List;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
