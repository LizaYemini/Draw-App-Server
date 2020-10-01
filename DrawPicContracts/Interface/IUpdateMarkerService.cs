using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IUpdateMarkerService
    {
        Response UpdateMarker(CreateMarkerRequest request);
    }
}