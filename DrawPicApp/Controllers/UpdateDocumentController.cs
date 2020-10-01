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
    public class UpdateDocumentController : ControllerBase
    {
        private IUpdateDocumentService _service;

        public UpdateDocumentController(IUpdateDocumentService service)
        {
            _service = service;
        }

        // Post api/SignIn
        [HttpPost]
        public Response UpdateDocument([FromBody] UpdateDocumentRequest request)
        {
            var ret = _service.UpdateDocument(request);
            return ret;
        }
    }
}
