using System;

namespace keepr_secret.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

        internal UserReturnModel Get ReturnModel()
        {
            return new UserReturnModel()
            {
                Id = Id,
                Username = Username,
                Email = Email
            };
        }
    }
}