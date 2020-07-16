using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class AuthenticateModel
    {
        public AuthenticateModel(User user)
        {
            Username = user.Username;
            UserRoleId = user.UserRoleId;
                

        }
        public string Username { get; set; }

        public int UserRoleId { get; set; }

        public string Token { get; set; }

        public DateTime expires { get; set; }

    }
}
