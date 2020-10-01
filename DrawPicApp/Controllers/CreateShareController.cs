using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateShareController : ControllerBase
    {
        private ICreateShareService _service;

        public CreateShareController(ICreateShareService service)
        {
            _service = service;
        }

        // Post api/CreateShare
        [HttpPost]
        public Response CreateShare([FromBody] CreateShareRequest request)
        {
            var ret = _service.CreateShare(request);
            return ret;
        }
    }
}
