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
    public class RemoveShareController : ControllerBase
    {
        private readonly IRemoveShareService _service;

        public RemoveShareController(IRemoveShareService service)
        {
            _service = service;
        }

        // Post api/RemoveShare
        [HttpPost]
        public Response RemoveShare([FromBody] RemoveShareRequest request)
        {
            var ret = _service.RemoveShare(request);
            return ret;
        }
    }
}
