using Demo.IReposotories;
using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Demo.Commons;
using Demo.IServices;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IBaseService<User> _service;

        public UserController(IBaseService<User> service) {
            _service = service;
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromBody] UserUpdateVM obj)
        {
            string status = "Error";
            string message = "Update User Fail";

            if (obj == null) return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = status, Message = message });

            User user = new User { Id = obj.Id, Email = obj.Email, PhoneNumber = obj.PhoneNumber };

            _service.Update(user);

            status = "";
            message="Success";

            return Ok(new { Status = status, Message = message });
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            string Status = "Error";
            string Message = "No item Found";

            var users = _service.GetAll();

            if (users.Count() == 0) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = Status, Message = Message });

            return users.ToList();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok(new Response { Status="Success", Message="User deleted"});
        }

        [HttpGet("{id:int}")]
        public JsonResult GetId(int id)
        {
            var result =_service.GetId(id);

            return new JsonResult(result);
        }
    }
}
