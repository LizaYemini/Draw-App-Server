using DrawPicContracts.DTO;
using DrawPicContracts.Interface;
using InfraContracts.DTO;
using System;
using System.Text;
using DIContracts;
using DrawPicContracts.Interface.Dal;

namespace AddDocumentService
{
    [Register(Policy.Transient, typeof(IAddDocumentService))]
    public class AddDocumentServiceImpl : IAddDocumentService
    {
        private readonly IDocumentsDal _dal;

        public AddDocumentServiceImpl(IDocumentsDal dal)
        {
            _dal = dal;
        }
        public Response AddDocument(AddDocumentRequest request)
        {
            
            try
            {
                string docId = GetId(request.Owner);
                _dal.AddDocument(request, docId);
                AddDocumentResponseOk ret = new AddDocumentResponseOk
                {
                    DocId = docId
                };
                return ret;
            }
            catch (Exception ex)
            {
                return new AppResponseError(ex.Message);
            }
        }

        private string GetId(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var ticks = DateTime.Now.Ticks;
            //User+ticks 
            var bytes = System.Text.Encoding.ASCII.GetBytes(input + ticks);
            var hashBytes = md5.ComputeHash(bytes);
            //var output = System.Text.Encoding.UTF8.GetString(hashBytes);
            StringBuilder sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
