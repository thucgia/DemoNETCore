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
    public class ProductController : ControllerBase
    {
        private readonly IBaseService<Product> _service;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(IBaseService<Product> service, ICategoryService categoryService, ISupplierService supplierService)
        {
            _service = service;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return new JsonResult(_service.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetId(int id)
        {
            return new JsonResult(_service.GetId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductVM obj)
        {
            string Status = "Error";
            string Message = "Product is Null";

            if (obj == null) return BadRequest(new Response { Status = Status, Message = Message });

            var category = _categoryService.getCategoryById(obj.CategoryId);

            var suppliers = (from item in obj.Suppliers
                            let supplierItem = _supplierService.GetSupplierById(item)
                            where supplierItem != null
                            select supplierItem);

            var productSuppliers = new List<ProductSupplier>();

            Product product = new Product
            {
                Name = obj.Name,
                Price = obj.Price,
                Quantity = obj.Quantity,
                Description = obj.Description,
                Category = category
            };

            foreach (Supplier item in suppliers)
            {
                productSuppliers.Add(new ProductSupplier{ Product = product, Supplier = item });
            }

            product.ProductSuppliers = productSuppliers;

            var result = await _service.Create(product);

            if (result == null)
            {
                Message = "Create Product Fail";
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Status, Message = Message });
            }

            Status = "Success";
            Message = "Created Product";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpPut]
        public ActionResult Update([FromBody] ProductVM obj)
        {
            string Status = "Error";
            string Message = "Product is Null";

            if (obj == null) return BadRequest(new Response { Status = Status, Message = Message });

            Product product = new Product
            {
                Name = obj.Name,
                Price = obj.Price,
                Quantity = obj.Quantity,
                Description = obj.Description
            };

            _service.Update(product);

            Status = "Success";
            Message = "Updated Product";

            return Ok(new Response { Status = Status, Message = Message });
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            string Status = "Success";
            string Message = "Deleted Product";

            _service.Delete(id);

            return Ok(new Response { Status = Status, Message = Message });
        }
    }
}
