using BLLayer.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.InterFace;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Model;
using Model.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.Implementation
{
    public class UserBL : IUserBL
    {
        private readonly IMongoRepository<User> _userRepository;

        private readonly IConfiguration _config;

        public UserBL(IConfiguration config, IMongoRepository<User> userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }



        public IEnumerable<User> GetAll()
        {
            return _userRepository.AsQueryable().ToList<User>().WithoutPasswords();

        }

        public User GetById(string id)
        {
            return _userRepository.FindById(id).WithoutPassword();
        }

        public void InsertUser(User userDetails)
        {
            _userRepository.InsertOne(userDetails);

        }

        public void UpdateUser(string id, User userDetails)
        {
            var objectId = new ObjectId(id);
            userDetails.Id = objectId;
            _userRepository.ReplaceOne(userDetails);

        }

        public void DeleteUser(string id)
        {
            _userRepository.DeleteById(id);

        }
        public string GenerateJSONWebToken(AuthenticateModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public AuthenticateModel AuthenticateUser(string username, string password)
        {
            AuthenticateModel authenticateModel;
            var user = _userRepository.AsQueryable().FirstOrDefault(x => x.Username == username && x.Password == password);
             
            if (user == null)
                return null;
            else
                authenticateModel = new AuthenticateModel(user);

            return authenticateModel;
        }


    }
}