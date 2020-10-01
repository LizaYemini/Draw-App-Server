using System;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace UpdateDocumentService
{
    [Register(Policy.Transient, typeof(IUpdateDocumentService))]
    public class UpdateDocumentServiceImpl: IUpdateDocumentService
    {
        private readonly IDocumentsDal _dal;
        public UpdateDocumentServiceImpl(IDocumentsDal dal)
        {
            _dal = dal;
        }

        public Response UpdateDocument(UpdateDocumentRequest request)
        {
            try
            {
                _dal.UpdateDocument(request);
                UpdateDocumentResponseOk ret = new UpdateDocumentResponseOk();
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
