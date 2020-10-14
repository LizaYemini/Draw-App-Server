using DrawPicContracts.DTO.LiveWatch;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface.LiveWatchServices
{
    public interface ICurrentlyWatchingService
    {
        Response CreateLiveWatchDoc (CreateLiveWatchDocRequest request);

        Response GetWatchersOfDoc(GetWatchersOfDocRequest request);

        Response RemoveLiveWatchDoc(RemoveLiveWatchDocRequest request);
    }
}