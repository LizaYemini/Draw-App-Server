using DrawPicContracts.DTO;
using InfraDal;
using NUnit.Framework;
using ShareDal;

namespace ShareDalTester
{
    public class Tests
    {
        private ShareDalImpl _dal;
        [SetUp]
        public void Setup()
        {
            _dal = new ShareDalImpl(new InfraDalImpl());
        }

        [Test]
        public void CreateShareTest()
        {
            var request = new CreateShareRequest()
            {
                DocId = "1",
                UserId = "Try@hotmail.com"
            };
            var ret = _dal.CreateShare(request);
            Assert.AreEqual(1, ret.Tables.Count);
        }

        [Test]
        public void GetShareTest1()
        {
            var request = new GetShareByDocIdRequest
            {
                DocId = "Try@hotmail.com"
            };
            var ret = _dal.GetShareByDocId(request);
            Assert.AreEqual(1, ret.Tables[0].Rows.Count);
        }

        [Test]
        public void GetShareTest2()
        {
            var request = new GetShareByDocIdRequest
            {
                DocId = "Liza091995@hotmail.com"
            };
            var ret = _dal.GetShareByDocId(request);
            Assert.AreEqual(0, ret.Tables[0].Rows.Count);
        }

        [Test]
        public void RemoveShareTest1()
        {
            var request = new RemoveShareRequest
            {
                DocId = "1",
                UserId = "Try@hotmail.com"
            };
            var ret = _dal.RemoveShare(request);
            Assert.AreEqual(0, ret.Tables[0].Rows.Count);
        }
    }
}