using System.Data;
using DrawPicContracts.DTO;

namespace DrawPicContracts.Interface.Dal
{
    public interface IDocumentsDal
    {
        public DataSet AddDocument(AddDocumentRequest request, string docId);

        public DataSet UpdateDocument(UpdateDocumentRequest request);

        public DataSet RemoveDocument(RemoveDocumentRequest request);

        public DataSet GetDocsByOwnerId(GetDocsByOwnerIdRequest request);
        public DataSet GetDocByDocId(GetDocByDocIdRequest request);
    }
}