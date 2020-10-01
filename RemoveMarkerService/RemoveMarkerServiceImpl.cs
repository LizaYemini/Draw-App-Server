using System;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace RemoveMarkerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]
    public class RemoveMarkerServiceImpl : IRemoveMarkerService
    {
        private readonly IMarkerDal _dal;

        public RemoveMarkerServiceImpl(IMarkerDal dal)
        {
            _dal = dal;
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
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
