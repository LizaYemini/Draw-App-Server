using DrawPicContracts.DTO;
using InfraContracts.DTO;

namespace DrawPicContracts.Interface
{
    public interface IGetSharesService
    {
        Response GetShareByUserId(GetShareByUserIdRequest request);

        Response GetShareByDocId(GetShareByDocIdRequest request);
    }
}