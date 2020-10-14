using System.Data;
using DrawPicContracts.DTO.LiveWatch;

namespace DrawPicContracts.Interface.Dal
{
    public interface ILiveWatchDocsDal
    {
        public DataSet CreateLiveWatchDoc(CreateLiveWatchDocRequest request);

        public DataSet RemoveLiveWatchDoc(RemoveLiveWatchDocRequest request);

        public DataSet GetWatchersOfDoc(GetWatchersOfDocRequest request);
    }
}