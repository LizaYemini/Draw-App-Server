using System;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace RemoveShareService
{
    [Register(Policy.Transient, typeof(IRemoveShareService))]
    public class RemoveShareServiceImpl : IRemoveShareService
    {
        private readonly IShareDal _dal;

        public RemoveShareServiceImpl(IShareDal dal)
        {
            _dal = dal;
        }
        public Response RemoveShare(RemoveShareRequest request)
        {
            try
            {
                _dal.RemoveShare(request);
                RemoveShareResponseOk ret = new RemoveShareResponseOk();
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
