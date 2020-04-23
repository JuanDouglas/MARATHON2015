using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.API.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserModel(User user) {
            Email = user.Email;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}