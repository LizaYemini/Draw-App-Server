using System;
using System.Collections.Generic;
using Contracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace GetAllDocumentsService
{
    [Register(Policy.Transient, typeof(IGetAllDocumentsService))]
    public class GetAllDocumentsService: IGetAllDocumentsService
    {
        readonly IShareDal _shareDal;
        readonly IDocumentsDal _docDal;
        public GetAllDocumentsService(IShareDal shareDal, IDocumentsDal docDal)
        {
            _shareDal = shareDal;
            _docDal = docDal;
        }

        public Response GetAllDocs(GetDocsByOwnerIdRequest request)
        {
            //DocumentDto[] docs;
            List<DocumentDto> docsList = new List<DocumentDto>();

            try
            {
                var dataSet = _docDal.GetDocsByOwnerId(request);
                var table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    DocumentDto temp = new DocumentDto()
                    {
                        DocId = table.Rows[i]["DocId"].ToString(),
                        DocumentName = table.Rows[i]["DocumentName"].ToString(),
                        ImageUrl = table.Rows[i]["ImageUrl"].ToString(),
                        Owner = table.Rows[i]["Owner"].ToString()
                    };
                    docsList.Add(temp);
                }

                GetShareByUserIdRequest sharedRequest = new GetShareByUserIdRequest
                {
                    UserId = request.Owner
                };
                dataSet = _shareDal.GetShareByUserId(sharedRequest);
                table = dataSet.Tables[0];
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    GetDocByDocIdRequest docIdRequest = new GetDocByDocIdRequest
                    {
                        DocId = table.Rows[i]["DocId"].ToString()
                    };
                    var dataSetDocId = _docDal.GetDocByDocId(docIdRequest);
                    var docIdTable = dataSetDocId.Tables[0];
                    DocumentDto doc = new DocumentDto()
                    {
                        DocId = docIdTable.Rows[0]["DocId"].ToString(),
                        DocumentName = docIdTable.Rows[0]["DocumentName"].ToString(),
                        ImageUrl = docIdTable.Rows[0]["ImageUrl"].ToString(),
                        Owner = docIdTable.Rows[0]["Owner"].ToString()
                    };
                    docsList.Add(doc);
                }

                GetDocsByOwnerIdResponse ret = new GetDocsByOwnerIdResponseOk
                {
                    Documents = docsList.ToArray()
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
