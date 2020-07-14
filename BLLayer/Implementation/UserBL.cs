using BLLayer.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.InterFace;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.Implementation
{
    public class UserBL : IUserBL
    {
        private readonly IMongoRepository<User> _userRepository;

        public UserBL(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }



        public IEnumerable<User> GetAll()
        {
            return _userRepository.AsQueryable().ToList<User>();

        }

        public User GetById(string id)
        {
            return _userRepository.FindById(id);

        }

        public void InsertUser(User userDetails)
        {
            _userRepository.InsertOne(userDetails);

        }

        public void UpdateUser(string id,User userDetails)
        {
            var objectId = new ObjectId(id);
            userDetails.Id = objectId;
            _userRepository.ReplaceOne(userDetails);

        }

        public void DeleteUser(string id)
        {
            _userRepository.DeleteById(id);

        }

    }
}