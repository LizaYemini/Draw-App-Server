using System.Data;
using DrawPicContracts.DTO;

namespace DrawPicContracts.Interface.Dal
{
    public interface IShareDal
    {
        public DataSet CreateShare(CreateShareRequest request);

        public DataSet RemoveShare(RemoveShareRequest request);

        public DataSet GetShareByUserId(GetShareByUserIdRequest request);

        public DataSet GetShareByDocId(GetShareByDocIdRequest request);
    }
}