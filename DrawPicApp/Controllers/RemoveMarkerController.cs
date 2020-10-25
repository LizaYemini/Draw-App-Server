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
    public class RemoveMarkerController : ControllerBase
    {

        private readonly IRemoveMarkerService _service;

        public RemoveMarkerController(IRemoveMarkerService service)
        {
            _service = service;
        }

        // Post api/RemoveShare
        [HttpPost]
        public Response RemoveMarker([FromBody] RemoveMarkerRequest request)
        {
            var ret = _service.RemoveMarker(request);
            return ret;
        }
    }
}
