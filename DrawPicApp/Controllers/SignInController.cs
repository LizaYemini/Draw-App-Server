using System.Collections.Generic;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private ISignInService _service;

        public SignInController(ISignInService service)
        {
            _service = service;
        }

        // Post api/SignIn
        [HttpPost]
        public Response SignIn([FromBody] SignInRequest request)
        {
            var ret = _service.SignIn(request);
            return ret;
        }
    }
}
