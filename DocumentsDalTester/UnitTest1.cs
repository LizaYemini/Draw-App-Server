using System;
using DocumentsDal;
using DrawPicApp;
using DrawPicContracts.DTO;
using InfraDal;
using NUnit.Framework;

namespace DocumentsDalTester
{
    public class Tests
    {
        private DocumentsDalImpl _dal;
        [SetUp]
        public void Setup()
        {
            _dal = new DocumentsDalImpl(new InfraDalImpl(), new ProductionDbContextConnectionString());
        }

        [Test]
        public void AddDocumentTest1()
        {
            var request = new AddDocumentRequest
            {
                ImageUrl = "assets/1.jpg",
                //request.ImageUrl = "DALTEST";
                DocumentName = "1",
                Owner = "Try@hotmail.com"
            };
            var docId = Guid.NewGuid();
            var ret= _dal.AddDocument(request, docId.ToString());
            Assert.AreEqual(1, ret.Tables.Count);
        }

        [Test]
        public void AddDocumentTest2()
        {
            var request = new AddDocumentRequest
            {
                ImageUrl = "assets/1.jpg",
                //request.ImageUrl = "DALTEST";
                DocumentName = "2",
                Owner = "Liza091995@hotmail.com"
            };
            var docId = Guid.NewGuid();
            var ret = _dal.AddDocument(request, docId.ToString());
            Assert.AreEqual(1, ret.Tables.Count);
        }
        [Test]
        public void UpdateDocumentTest1()
        {
            var request = new UpdateDocumentRequest
            {
                ImageUrl = "assets/1.jpg",
                DocumentName = "UpdateDocumentTest",
                Owner = "Try@hotmail.com",
                DocId = "3"
            };
            var docId = Guid.NewGuid();
            var ret = _dal.UpdateDocument(request);
            Assert.AreEqual(1, ret.Tables.Count);
        }

        [Test]
        public void RemoveDocumentTest1()
        {
            var request = new RemoveDocumentRequest
            {
                DocId = "3"
            };
            var ret = _dal.RemoveDocument(request);
            Assert.AreEqual(1, ret.Tables.Count);
        }

        [Test]
        public void GetDocsByOwnerId1()
        {
            var request = new GetDocsByOwnerIdRequest
            {
                Owner = "Liza091995@hotmail.com"
            };
            var ret = _dal.GetDocsByOwnerId(request);
            var ret2 = ret.Tables[0].Rows[0]["docId"].ToString();
            var ret3 = ret.Tables[0].Rows[1]["docId"].ToString();
            Assert.AreEqual("1", ret2);
            Assert.AreEqual("2787587f-3571-4c90-ab6e-bb726dda465d", ret3);
        }

        [Test]
        public void GetDocByDocId1()
        {
            var request = new GetDocByDocIdRequest
            {
                DocId = "2787587f-3571-4c90-ab6e-bb726dda465d"
            };
            var ret = _dal.GetDocByDocId(request);
            var ret2 = ret.Tables[0].Rows[0]["Owner"].ToString();
            Assert.AreEqual("Liza091995@hotmail.com", ret2);
        }
    }
}