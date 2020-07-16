using DataAccessLayer.Entity;
using Model.Model;
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
        string GenerateJSONWebToken(AuthenticateModel userInfo);
        AuthenticateModel AuthenticateUser(string username, string password);
    }
}