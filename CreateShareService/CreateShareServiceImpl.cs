using System;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace CreateShareService
{
    [Register(Policy.Transient, typeof(ICreateShareService))]
    public class CreateShareServiceImpl : ICreateShareService
    {
        private readonly IShareDal _dal;

        public CreateShareServiceImpl(IShareDal dal)
        {
            _dal = dal;
        }
        public Response CreateShare(CreateShareRequest request)
        {
            try
            {
                _dal.CreateShare(request);
                CreateShareResponseOk ret = new CreateShareResponseOk();
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
