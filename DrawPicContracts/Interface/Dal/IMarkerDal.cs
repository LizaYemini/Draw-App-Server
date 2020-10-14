using System.Data;
using DrawPicContracts.DTO;

namespace DrawPicContracts.Interface.Dal
{
    public interface IMarkerDal
    {
        public DataSet CreateMarker(CreateMarkerRequest request);

        public DataSet RemoveMarker(RemoveMarkerRequest request);

        public DataSet GetMarkers(GetMarkersRequest request);

        public DataSet UpdateMarker(CreateMarkerRequest request);
    }
}