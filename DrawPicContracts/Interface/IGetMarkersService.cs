using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IGetMarkersService
    {
        Response GetMarkers(GetMarkersRequest request);
    }
}