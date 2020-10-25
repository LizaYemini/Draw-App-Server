using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDocumentController : ControllerBase
    {
        private readonly IAddDocumentService _service;

        public AddDocumentController(IAddDocumentService service)
        {
            _service = service;
        }

        // Post api/AddDocument
        [HttpPost]
        public Response AddDocument([FromBody] AddDocumentRequest request)
        {
            var ret = _service.AddDocument(request);
            return ret;
        }
    }
}
