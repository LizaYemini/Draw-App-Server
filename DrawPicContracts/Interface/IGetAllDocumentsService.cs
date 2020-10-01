using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IGetAllDocumentsService
    {
        Response GetAllDocs(GetDocsByOwnerIdRequest request);
    }
}