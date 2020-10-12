using System;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.WebSocket;
using InfraContracts.DTO;

namespace RemoveMarkerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]
    public class RemoveMarkerServiceImpl : IRemoveMarkerService
    {
        private readonly IMarkerDal _dal;
        private readonly IMarkerWebSocket _markerWebSocket;
        public RemoveMarkerServiceImpl(IMarkerDal dal, IMarkerWebSocket markerWebSocket)
        {
            _dal = dal;
            _markerWebSocket = markerWebSocket;
        }
        public Response RemoveMarker(RemoveMarkerRequest request)
        {
            try
            {
                _dal.RemoveMarker(request);
                RemoveMarkerResponseOk ret = new RemoveMarkerResponseOk
                {
                    MarkerId = request.MarkerId
                };

                _markerWebSocket.SendRemoveMarker(request.MarkerId);

                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
