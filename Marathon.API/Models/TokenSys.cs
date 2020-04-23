using System;
using System.Timers;

namespace Marathon.API.Models
{
    public class TokenSys
    {
        public Guid TokenGuid { get; private set; }
        public TimeSpan TokenGeneratedDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public TokenSys(Guid token,string email,string password)
        {
            TokenGuid = token;
            Email = email;
            Password = password;
            var now = DateTime.Now;
            TokenGeneratedDate = new TimeSpan(now.Hour, now.Minute, now.Second);
        }
    }
}