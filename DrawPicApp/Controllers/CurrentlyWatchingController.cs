using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrawPicContracts.DTO.LiveWatch;
using DrawPicContracts.Interface.LiveWatchServices;
using InfraContracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicApp.Controllers
{
    
    [ApiController]
    public class CurrentlyWatchingController : ControllerBase
    {
        private readonly ICurrentlyWatchingService _service;

        public CurrentlyWatchingController(ICurrentlyWatchingService service)
        {
            _service = service;
        }

        [Route("api/CurrentlyWatching/CreateLiveWatchDoc")]
        [HttpPost]
        public Response CreateLiveWatchDoc([FromBody] CreateLiveWatchDocRequest request)
        {
            var ret = _service.CreateLiveWatchDoc(request);
            return ret;
        }

        [Route("api/[controller]/RemoveLiveWatchDoc")]
        [HttpPost]
        public Response RemoveLiveWatchDoc([FromBody] RemoveLiveWatchDocRequest request)
        {
            var ret = _service.RemoveLiveWatchDoc(request);
            return ret;
        }

        [Route("api/CurrentlyWatching/GetWatchersOfDoc")]
        [HttpPost]
        public Response GetWatchersOfDoc([FromBody] GetWatchersOfDocRequest request)
        {
            var ret = _service.GetWatchersOfDoc(request);
            return ret;
        }
    }
}
