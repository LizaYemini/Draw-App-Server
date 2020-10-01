using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface ICreateMarkerService
    {
        Response CreateMarker(CreateMarkerRequest request);
    }
}