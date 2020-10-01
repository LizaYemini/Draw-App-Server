using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IRemoveDocumentService
    {
        Response RemoveDocument(RemoveDocumentRequest request);
    }
}