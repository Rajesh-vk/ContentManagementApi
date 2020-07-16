using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLLayer.Interface;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Utility;

namespace ContentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        // GET: api/User

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userBL.GetAll().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var item = _userBL.GetById(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] User userDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userBL.InsertUser(userDetails);

            return CreatedAtAction("Get", new { id = userDetails.Id }, userDetails.WithoutPassword());

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id,[FromBody] User userDetails)
        {
            _userBL.UpdateUser(id,userDetails);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingItem = _userBL.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }
            _userBL.DeleteUser(id);

            return Ok();
        }

        [HttpPost]
        [Route("GetToken")]
        public IActionResult GetToken([FromBody]User userParam)
        {
            IActionResult response = Unauthorized();
            var user = _userBL.AuthenticateUser(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (user != null)
            {
                var tokenString = _userBL.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, expires = DateTime.Now.AddMinutes(120) });
                user.Token = tokenString;
                user.expires = DateTime.Now.AddMinutes(120);
            }

            return Ok(user);
        }

    }
}
