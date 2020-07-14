using DataAccessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entity
{
    [EntityCollectionName("User")]
    public class User : Document
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string EmailId { get; set; }

        public int UserRoleId { get; set; }
    }
}
