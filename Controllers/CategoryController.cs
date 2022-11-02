using Demo.Commons;
using Demo.IServices;
using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseService<Category> _service;

        public CategoryController(IBaseService<Category> service) {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new JsonResult(_service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryVM obj)
        {
            //if (!ModelState.IsValid)
            //{
            //    return NotFound();
            //}

            //ModelState.ClearValidationState(nameof(Category));
            //if (!TryValidateModel(obj, nameof(Category)))
            //{
            //    //return Page();
            //}
            
            string Status = "Error";
            string Message = "Category is Null";

            if (obj == null) return StatusCode(StatusCodes.Status204NoContent, new Response { Status = Status, Message = Message });

            var category = new Category { Name = obj.Name };
            var result = await _service.Create(category);

            if (result == null)
            {
                Message = "Create Category Fail";
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Status, Message = Message });
            }

            Status = "Success";
            Message = "Created Category";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpPut]
        public ActionResult Update([FromBody] Category obj)
        {
            string Status = "Error";
            string Message = "Category is Null";

            if (obj == null || obj.Name == null) return StatusCode(StatusCodes.Status204NoContent, new Response { Status = Status, Message = Message });

            _service.Update(obj);

            Status = "Success";
            Message = "Updated Category";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            string Status = "Success";
            string Message = "Deleted Category";

            _service.Delete(id);

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpGet("{id:int}")]
        public ActionResult GetId(int id)
        {
            string Status = "Error";
            string Message = "Caterogy not existed";

            var result = _service.GetId(id);

            if(result == null) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = Status, Message = Message });

            return new JsonResult(result);
        }
    }
}
