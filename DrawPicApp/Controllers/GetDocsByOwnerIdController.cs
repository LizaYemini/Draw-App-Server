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
    public class GetDocsByOwnerIdController : ControllerBase
    {
        private IGetDocumentService _service;

        public GetDocsByOwnerIdController(IGetDocumentService service)
        {
            _service = service;
        }

        // Post api/GetDocsByOwnerId
        [HttpPost]
        public Response GetDocsByOwnerId([FromBody] GetDocsByOwnerIdRequest request)
        {
            var ret = _service.GetDocsByOwnerId(request);
            return ret;
        }

        /*
        // Post api/GetDocByDocId
        [HttpPost]
        public Response GetDocByDocId([FromBody] GetDocByDocIdRequest request)
        {
            var ret = _service.GetDocByDocId(request);
            return ret;
        }
        */
    }
}
