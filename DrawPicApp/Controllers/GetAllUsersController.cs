using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllUsersController : ControllerBase
    {
        private readonly IGetAllUsersService _service;

        public GetAllUsersController(IGetAllUsersService service)
        {
            _service = service;
        }

        // Post api/GetAllUsers
        [HttpPost]
        public Response GetAllUsers()
        {
            var ret = _service.GetAllUsers();
            return ret;
        }
    }
}
