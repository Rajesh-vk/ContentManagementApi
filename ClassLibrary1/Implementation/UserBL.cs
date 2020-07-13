using BLLayer.Interface;
using DataAccessLayer.Entity;
using DataAccessLayer.InterFace;
using System;
using System.Collections.Generic;
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


       
        public async Task AddPerson(string firstName, string lastName)
        {
            var person = new User()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            await _userRepository.InsertOneAsync(person);
        }

        public IEnumerable<string> GetPeopleData()
        {
            var people = _userRepository.FilterBy(
                filter => filter.FirstName != "test",
                projection => projection.FirstName
            );
            return people;
        }

    }
}
