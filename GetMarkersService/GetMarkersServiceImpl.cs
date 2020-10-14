using System;
using System.Collections.Generic;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.Dal;
using InfraContracts.DTO;

namespace GetMarkersService
{
    [Register(Policy.Transient, typeof(IGetMarkersService))]
    public class GetMarkersServiceImpl : IGetMarkersService
    {
        private readonly IMarkerDal _dal;
        public GetMarkersServiceImpl(IMarkerDal dal)
        {
            _dal = dal;
        }
        public Response GetMarkers(GetMarkersRequest request)
        {
            List<MarkerDto> markersList = new List<MarkerDto>();

            try
            {
                var dataSet = _dal.GetMarkers(request);
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    MarkerDto temp = new MarkerDto()
                    {
                        DocId = table.Rows[i]["DocId"].ToString(),
                        MarkerId = table.Rows[i]["MarkerId"].ToString(),
                        MarkerType = table.Rows[i]["MarkerType"].ToString(),
                        ForColor = table.Rows[i]["ForColor"].ToString(),
                        BackColor = table.Rows[i]["BackColor"].ToString(),
                        UserId = table.Rows[i]["UserId"].ToString(),
                        LocationX = Convert.ToDouble(table.Rows[i]["LocationX"].ToString()),
                        LocationY = Convert.ToDouble(table.Rows[i]["LocationY"].ToString()),
                        Height = Convert.ToDouble(table.Rows[i]["Height"].ToString()),
                        Width = Convert.ToDouble(table.Rows[i]["Width"].ToString())
                        
                        /*
                        LocationX = Convert.ToInt32((decimal)table.Rows[i]["LocationX"]),
                        LocationY = Convert.ToInt32((decimal)table.Rows[i]["LocationY"]),
                        Height = Convert.ToInt32((decimal)table.Rows[i]["Height"]),
                        Width= Convert.ToInt32((decimal)table.Rows[i]["Width"])
                        */
                        
                    };
                    markersList.Add(temp);
                }

                GetMarkersResponseOk ret = new GetMarkersResponseOk
                {
                    Markers = markersList.ToArray()
                };
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
