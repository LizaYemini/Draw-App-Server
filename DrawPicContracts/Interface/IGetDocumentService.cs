using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IGetDocumentService
    {
        Response GetDocsByOwnerId(GetDocsByOwnerIdRequest request);

        Response GetDocByDocId(GetDocByDocIdRequest request);
    }
}