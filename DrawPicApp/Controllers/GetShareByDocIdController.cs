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
    public class GetShareByDocIdController : ControllerBase
    {
        readonly IGetSharesService _service;
        public GetShareByDocIdController(IGetSharesService service)
        {
            _service = service;
        }

        // Post api/GetAllDocs
        [HttpPost]
        public Response GetShareByDocId([FromBody] GetShareByDocIdRequest request)
        {
            var ret = _service.GetShareByDocId(request);
            return ret;
        }
    }
}
