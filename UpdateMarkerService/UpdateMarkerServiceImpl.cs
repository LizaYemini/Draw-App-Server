using DrawPicContracts.Interface;
using System;
using Contracts;
using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace UpdateMarkerService
{
    [Register(Policy.Transient, typeof(IUpdateMarkerService))]
    public class UpdateMarkerServiceImpl : IUpdateMarkerService
    {
        private IMarkerDal _dal;
        public UpdateMarkerServiceImpl(IMarkerDal dal)
        {
            _dal = dal;
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
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
