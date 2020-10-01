using DocumentsDal;
using DrawPicContracts.DTO;
using GetDocumentService;
using InfraDal;
using NUnit.Framework;

namespace GetDocumentServiceTester
{
    public class Tests
    {
        private DocumentsDalImpl _docDal;
        private GetDocumentServiceImpl _service;
        [SetUp]
        public void Setup()
        {
            _docDal = new DocumentsDalImpl(new InfraDalImpl());
            _service = new GetDocumentServiceImpl(_docDal);
        }

        [Test]
        public void GetDocsByOwnerIdTest1()
        {
            GetDocsByOwnerIdRequest request = new GetDocsByOwnerIdRequest
            {
                Owner = "Liza091995@hotmail.com"
            };
            var ret = _service.GetDocsByOwnerId(request);
            var responseOk = new GetDocsByOwnerIdResponseOk();
            Assert.AreEqual(responseOk.ResponseType, ret.ResponseType);
        }

        [Test]
        public void GetDocByDocIdTest1()
        {
            GetDocByDocIdRequest request = new GetDocByDocIdRequest()
            {
                DocId = "1"
            };
            var ret = _service.GetDocByDocId(request);
            var responseOk = new GetDocByDocIdResponseOk
            {
                Document = new DocumentDto()
                {
                    DocId = "1",
                    ImageUrl = "XXX",
                    DocumentName = "XXX",
                    Owner = "Liza091995@hotmail.com"
                }
            };
            //Assert.AreEqual(responseOk, ret);
            Assert.AreEqual(responseOk.ResponseType, ret.ResponseType);
        }
    }
}