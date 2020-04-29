using Newtonsoft.Json;

namespace Marathon.API.Models
{
    public class RoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public RoleModel(Data.Role role)
        {
            RoleId = role.RoleId;
            RoleName = role.RoleName;
        }
        public override string ToString()
        {
            return JsonHelper.FormatJson(JsonConvert.SerializeObject(this));
        }
    }
}