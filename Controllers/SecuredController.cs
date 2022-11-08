using Demo.IServices;
using Demo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecuredController : ControllerBase
    {
        private readonly IAuthService _service;
        public SecuredController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetSecuredData([FromBody] UserLoginVM userLogin)
        {
            var token = _service.Authenticate(userLogin);
            return new JsonResult(token);
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody]UserRegisterVM obj)
        {
            var token = await _service.Register(obj);
            return new JsonResult(token);
        }
    }
}
