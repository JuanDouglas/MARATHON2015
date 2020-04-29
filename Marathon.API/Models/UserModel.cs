using Newtonsoft.Json;

namespace Marathon.API.Models
{
    public class UserModel
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get;private set; }
        public string LastName { get; private set; }
        public RoleModel Role { get; private set; }
        public UserModel(Data.User user, Data.Role role)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Role = new RoleModel(role);
        }
        public override string ToString()
        {
            var convert = JsonConvert.SerializeObject(new { UserModel = this, RoleId = Role});
            var result= JsonHelper.FormatJson(convert);
            return result;
        }
    }
}