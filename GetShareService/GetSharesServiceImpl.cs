using System;
using System.Collections.Generic;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace GetShareService
{
    [Register(Policy.Transient, typeof(IGetSharesService))]
    public class GetSharesServiceImpl : IGetSharesService
    {
        private readonly IShareDal _dal;

        public GetSharesServiceImpl(IShareDal dal)
        {
            _dal = dal;
        }

        public Response GetShareByDocId(GetShareByDocIdRequest request)
        {
            List<string> usersList = new List<string>();

            try
            {
                var dataSet = _dal.GetShareByDocId(request);
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    usersList.Add(table.Rows[i]["UserId"].ToString());
                }

                var ret = new GetShareByDocIdResponseOk
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

        public Response GetShareByUserId(GetShareByUserIdRequest request)
        {
            //DocumentDto[] docs;
            List<string> docsList = new List<string>();

            try
            {
                var dataSet = _dal.GetShareByUserId(request);
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    docsList.Add(table.Rows[i]["DocId"].ToString());
                }

                var ret= new GetShareByUserIdResponseOk
                {
                    DocsIds = docsList.ToArray()
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
