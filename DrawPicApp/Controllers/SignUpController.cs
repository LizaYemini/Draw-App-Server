using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _service;

        public SignUpController(ISignUpService service)
        {
            _service = service;
        }

        // Post api/SignUp
        [HttpPost]
        public Response SignUp([FromBody] SignUpRequest request)
        {
            var ret = _service.SignUp(request);
            return ret;
        }
    }
}
