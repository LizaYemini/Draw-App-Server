using AddDocumentService;
using DocumentsDal;
using DrawPicApp;
using DrawPicContracts.DTO;
using InfraDal;
using NUnit.Framework;

namespace AddDocumentServiceTest
{
    public class Tests
    {
        private AddDocumentServiceImpl _service;
        private DocumentsDalImpl _dal;

        [SetUp]
        public void Setup()
        {
            _dal = new DocumentsDalImpl(new InfraDalImpl(), new ProductionDbContextConnectionString());
            _service = new AddDocumentServiceImpl(_dal);
        }

        [Test]
        public void Test1()
        {
            var request = new AddDocumentRequest
            {
                ImageUrl = "assets/1.jpg",
                //request.ImageUrl = "DALTEST";
                DocumentName = "AddDocumentTest",
                Owner = "Try@hotmail.com"
            };
            var ret = _service.AddDocument(request);
            Assert.AreEqual(new AddDocumentResponseOk(), ret);
        }
    }
}