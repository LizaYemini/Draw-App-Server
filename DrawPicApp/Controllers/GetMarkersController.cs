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
    public class GetMarkersController : ControllerBase
    {
        readonly IGetMarkersService _service;
        public GetMarkersController(IGetMarkersService service)
        {
            _service = service;
        }

        // Post api/GetMarkers
        [HttpPost]
        public Response GetMarkers([FromBody] GetMarkersRequest request)
        {
            var ret = _service.GetMarkers(request);
            return ret;
        }
    }
}
