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
    public class GetAllDocsController : ControllerBase
    {
        readonly IGetAllDocumentsService _service;
        public GetAllDocsController(IGetAllDocumentsService service)
        {
            _service = service;
        }

        // Post api/GetAllDocs
        [HttpPost]
        public Response GetAllDocs([FromBody] GetDocsByOwnerIdRequest request)
        {
            var ret = _service.GetAllDocs(request);
            return ret;
        }
    }
}
