using System;
using Newtonsoft.Json;
namespace Marathon.API.Models
{
    public class TokenSys
    {
        public Guid TokenGuid { get; private set; }
        public TimeSpan TokenGeneratedDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Enums.LevelAcess AcessLevel { get; private set; }
        public TokenSys(Guid token, string email, string password,Enums.LevelAcess acessLevel)
        {
            TokenGuid = token;
            Email = email;
            Password = password;
            AcessLevel = acessLevel;
            var now = DateTime.Now;
            TokenGeneratedDate = new TimeSpan(now.Hour, now.Minute, now.Second);
        }
        public override string ToString()
        {
            return JsonHelper.FormatJson(JsonConvert.SerializeObject(this));
        }
    }
}