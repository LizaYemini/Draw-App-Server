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
    public class CreateMarkerController : ControllerBase
    {
        private readonly ICreateMarkerService _service;

        public CreateMarkerController(ICreateMarkerService service)
        {
            _service = service;
        }

        // Post api/CreateMarker
        [HttpPost]
        public Response CreateMarker([FromBody] CreateMarkerRequest request)
        {
            var ret = _service.CreateMarker(request);
            return ret;
        }
    }
}
