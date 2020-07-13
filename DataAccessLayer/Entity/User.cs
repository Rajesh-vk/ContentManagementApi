using DataAccessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entity
{
    [EntityCollectionName("User")]
    public class User : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
