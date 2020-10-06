using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IAddDocumentService
    {
        Response AddDocument(AddDocumentRequest request);
    }
}