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
    public class RemoveDocumentController : ControllerBase
    {
        private readonly IRemoveDocumentService _service;

        public RemoveDocumentController(IRemoveDocumentService service)
        {
            _service = service;
        }

        // Post api/AddDocument
        [HttpPost]
        public Response RemoveDocument([FromBody] RemoveDocumentRequest request)
        {
            var ret = _service.RemoveDocument(request);
            return ret;
        }
    }
}
