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
    public class UpdateMarkerController : ControllerBase
    {
        private readonly IUpdateMarkerService _service;
        public UpdateMarkerController(IUpdateMarkerService service)
        {
            _service = service;
        }

        // Post api/GetAllDocs
        [HttpPost]
        public Response UpdateMarker([FromBody] CreateMarkerRequest request)
        {
            var ret = _service.UpdateMarker(request);
            return ret;
        }
    }
}
