using System;

namespace Marathon.API.Models
{
    public class TokenUser
    {
        public Guid Token { get; private set; }
        public DateTime GeneratedDate { get; private set; }
        public TokenUser(Guid token, DateTime generetedDate)
        {
            Token = token;
            GeneratedDate = generetedDate;
        }
    }
}