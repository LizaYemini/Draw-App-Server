using System;
using System.Collections.Generic;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.DTO.LiveWatch;
using DrawPicContracts.DTO.LiveWatch.Response;
using DrawPicContracts.Interface.Dal;
using DrawPicContracts.Interface.LiveWatchServices;
using InfraContracts.DTO;

namespace CurrentlyWatchingService
{
    [Register(Policy.Transient, typeof(ICurrentlyWatchingService))]
    public class CurrentlyWatchingServiceImpl : ICurrentlyWatchingService
    {
        private readonly ILiveWatchDocsDal _dal;
        public CurrentlyWatchingServiceImpl(ILiveWatchDocsDal dal)
        {
            _dal = dal;
        }
        public Response CreateLiveWatchDoc(CreateLiveWatchDocRequest request)
        {
            try
            {
                _dal.CreateLiveWatchDoc(request);
                CreateLiveWatchDocResponseOk ret = new CreateLiveWatchDocResponseOk
                {
                    UserId = request.UserId,
                    DocId = request.DocId
                };
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }

        public Response GetWatchersOfDoc(GetWatchersOfDocRequest request)
        {
            List<string> usersList = new List<string>();

            try
            {
                var dataSet = _dal.GetWatchersOfDoc(request);
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    usersList.Add(table.Rows[i]["UserId"].ToString());
                }

                var ret = new GetWatchersOfDocResponseOk()
                {
                    UsersIds = usersList.ToArray()
                };
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }

        public Response RemoveLiveWatchDoc(RemoveLiveWatchDocRequest request)
        {
            try
            {
                _dal.RemoveLiveWatchDoc(request);
                RemoveLiveWatchDocResponseOk ret = new RemoveLiveWatchDocResponseOk();
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
    }
}
