using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IRemoveShareService
    {
        Response RemoveShare(RemoveShareRequest request);
    }
}