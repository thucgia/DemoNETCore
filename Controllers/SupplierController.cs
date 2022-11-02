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

    public class SupplierController : ControllerBase
    {
        private readonly IBaseService<Supplier> _service;

        public SupplierController(IBaseService<Supplier> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SupplierVM obj)
        {
            string Status = "Error";
            string Message = "Supplier is Null";

            if (obj == null) return BadRequest(new Response { Status = Status, Message = Message });

            Supplier supplier = new Supplier
            {
                Name = obj.Name
            };

            var result = await _service.Create(supplier);


            if (result == null) {
                Message = "Create Supplier Fail";
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Status, Message = Message });
            }

            Status = "Success";
            Message = "Created Supplier";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpPut]
        public ActionResult Update(Supplier obj)
        {
            string Status = "Error";
            string Message = "Supplier is Null";

            if (obj == null) return BadRequest(new Response { Status = Status, Message = Message });

            _service.Update(obj);

            Status = "Success";
            Message = "Updated Supplier";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpGet("{id:int}")]
        public ActionResult GetId(int id)
        {
            string Status = "Error";
            string Message = "Supplier not found";

            var supplier = _service.GetId(id);

            if (supplier == null) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = Status, Message = Message });

            return new JsonResult(supplier);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            string Status = "Error";
            string Message = "No item found";

            var result = _service.GetAll();

            if (result.Count() == 0) return StatusCode(StatusCodes.Status404NotFound, new Response { Status = Status, Message = Message });

            return new JsonResult(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            string Status = "Success";
            string Message = "Deleted Supplier";

            _service.Delete(id);

            return Ok(new Response { Status = Status, Message = Message });
        }
    }
}
