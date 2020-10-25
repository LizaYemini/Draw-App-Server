using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfraContracts.DTO;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService _service;

        public ValidateController(IValidateService service)
        {
            _service = service;
        }

        // Post api/Validate
        [HttpPost]
        public Response ValidateId([FromBody] ValidateIdRequest request)
        {
            var ret = _service.ValidateId(request);
            return ret;
        }
    }
}
