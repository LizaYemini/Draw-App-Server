using DrawPicContracts.Interface;
using System;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface.WebSocket;
using InfraContracts.DTO;

namespace UpdateMarkerService
{
    [Register(Policy.Transient, typeof(IUpdateMarkerService))]
    public class UpdateMarkerServiceImpl : IUpdateMarkerService
    {
        private IMarkerDal _dal;
        private readonly IMarkerWebSocket _markerWebSocket;
        public UpdateMarkerServiceImpl(IMarkerDal dal, IMarkerWebSocket markerWebSocket)
        {
            _dal = dal;
            _markerWebSocket = markerWebSocket;
        }
        public Response UpdateMarker(CreateMarkerRequest request)
        {
            try
            {
                _dal.UpdateMarker(request);
                UpdateMarkerResponseOk ret = new UpdateMarkerResponseOk
                {
                    Marker = request.Marker
                };

                _markerWebSocket.SendUpdateMarker(request.Marker);
                return ret;

            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
