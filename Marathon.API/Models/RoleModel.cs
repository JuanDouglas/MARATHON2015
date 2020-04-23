namespace Marathon.API.Models
{
    public class RoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public RoleModel(Role role)
        {
            RoleId = role.RoleId;
            RoleName = role.RoleName;
        }
    }
}