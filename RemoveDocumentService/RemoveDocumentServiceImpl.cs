using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using System;
using DIContracts;
using DrawPicContracts.Interface.Dal;

namespace RemoveDocumentService
{
    [Register(Policy.Transient, typeof(IRemoveDocumentService))]
    public class RemoveDocumentServiceImpl : IRemoveDocumentService
    {
        private readonly IDocumentsDal _dal;

        public RemoveDocumentServiceImpl(IDocumentsDal dal)
        {
            _dal = dal;
        }

        public Response RemoveDocument(RemoveDocumentRequest request)
        {
            try
            {
                _dal.RemoveDocument(request);
                RemoveDocumentResponseOk ret = new RemoveDocumentResponseOk();
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
