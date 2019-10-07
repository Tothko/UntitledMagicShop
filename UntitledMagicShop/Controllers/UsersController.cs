using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Entities;

namespace UntitledMagicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService; 

        private bool IsValid(User user,out String msg)
        {
            msg = "";
            if (user == null)
                msg = "Request has to containt user field";
            if (user.FirstName.Length == 0)
                msg = "User first name can not be empty";
            if (user.Password.Length == 0)
                msg = "User password can not be empty";
            return msg.Length == 0;
        }

        public UsersController(IUserService service)
        {
            _userService = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.ReadAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.ReadById(id);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            String message = "";
            if (!IsValid(user, out message))
            {
                return BadRequest(message);
            }
            try
            {
                var newUser = _userService.Create(user);
                if (newUser != null)
                    return Ok(newUser);
                else
                    return BadRequest("User creation failed");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            String message = "";
            if (!IsValid(user, out message))
            {
                return BadRequest(message);
            }
            if (id != user.ID)
                return BadRequest("User id does not match");

            try
            {
                var updatedUser = _userService.Update(user);
                if (updatedUser != null)
                    return Ok(updatedUser);
                else
                    return BadRequest("User update failed");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = _userService.ReadById(id);
            if (user == null)
                return NotFound();

            try
            {
                _userService.Delete(user);
                return Ok(user);
            }catch(Exception ex)
            {
                return BadRequest("Error deleting user");
            }
        }
    }
}