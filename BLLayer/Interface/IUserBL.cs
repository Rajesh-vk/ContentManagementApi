using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.Interface
{
    public interface IUserBL
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        void InsertUser(User userDetails);
        void UpdateUser(string id,User userDetails);
        void DeleteUser(string id);
        string GenerateJSONWebToken(User userInfo);
        User AuthenticateUser(string username, string password);
    }
}