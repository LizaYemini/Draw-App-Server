using System;
using System.Collections.Generic;
using DIContracts;
using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;

namespace GetDocumentService
{
    [Register(Policy.Transient, typeof(IGetDocumentService))]
    public class GetDocumentServiceImpl : IGetDocumentService
    {
        private readonly IDocumentsDal _docDal;
        public GetDocumentServiceImpl(IDocumentsDal docDal)
        {
            _docDal = docDal;
        }
        public Response GetDocByDocId(GetDocByDocIdRequest request)
        {
            DocumentDto doc;

            try
            {
                var dataSet = _docDal.GetDocByDocId(request);
                var table = dataSet.Tables[0];
                doc = new DocumentDto()
                {
                    DocId = table.Rows[0]["DocId"].ToString(),
                    DocumentName = table.Rows[0]["DocumentName"].ToString(),
                    ImageUrl = table.Rows[0]["ImageUrl"].ToString(),
                    Owner = table.Rows[0]["Owner"].ToString()
                };
                GetDocByDocIdResponse ret = new GetDocByDocIdResponseOk()
                {
                    Document = doc
                };
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }
        public Response GetDocsByOwnerId(GetDocsByOwnerIdRequest request)
        {
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
