using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IRemoveMarkerService
    {
        Response RemoveMarker(RemoveMarkerRequest request);
    }
}