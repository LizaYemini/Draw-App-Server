using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IUpdateDocumentService
    {
        Response UpdateDocument(UpdateDocumentRequest request);
    }
}