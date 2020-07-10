using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace ContentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMongoRepository<Person> _peopleRepository;

        public ValuesController(IMongoRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }


        // GET api/    [HttpPost("registerPerson")]
        public async Task AddPerson(string firstName, string lastName)
        {
            var person = new Person()
            {
                FirstName = "John",
                LastName = "Doe"
            };

            await _peopleRepository.InsertOneAsync(person);
        }

        [HttpGet("getPeopleData")]
        public IEnumerable<string> GetPeopleData()
        {
            var people = _peopleRepository.FilterBy(
                filter => filter.FirstName != "test",
                projection => projection.FirstName
            );
            return people;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
