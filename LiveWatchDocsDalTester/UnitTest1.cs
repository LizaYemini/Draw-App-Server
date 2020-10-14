using DrawPicApp;
using DrawPicContracts.DTO.LiveWatch;
using DrawPicContracts.Interface.Dal;
using InfraContracts.DTO;
using InfraDal;
using LiveWatchDocsDal;
using NUnit.Framework;

namespace LiveWatchDocsDalTester
{
    public class Tests
    {
        private ILiveWatchDocsDal _dal;
        
        [SetUp]
        public void Setup()
        {
            _dal = new LiveWatchDocsDalImpl(new InfraDalImpl(), new ProductionDbContextConnectionString());
        }
        /*
        [Test]
        public void CreateLiveWatchTestNotExists()
        {
            var request = new CreateLiveWatchDocRequest
            {
                DocId = "1",
                UserId = "Liza091995@hotmail.com"
            };
            var ret = _dal.CreateLiveWatchDoc(request);

            Assert.AreEqual(0, ret.Tables.Count);
        } */

        [Test]
        public void CreateLiveWatchTestExists()
        {
            var request = new CreateLiveWatchDocRequest
            {
                DocId = "3F558898BEDE55D2F6F2C454AA6D2774",
                UserId = "Liza091995@hotmail.com"
            };
            var ret = _dal.CreateLiveWatchDoc(request);

            Assert.AreEqual(1, ret.Tables.Count);
        }

        [Test]
        public void GetWatchersOfDocTest()
        {
            var request = new GetWatchersOfDocRequest()
            {
                DocId = "3F558898BEDE55D2F6F2C454AA6D2774"
            };
            var ret = _dal.GetWatchersOfDoc(request);

            Assert.AreEqual(1, ret.Tables.Count);

            var userId = ret.Tables[0].Rows[0]["userId"].ToString();

            Assert.AreEqual("Liza091995@hotmail.com", userId);
        }

        [Test]
        public void RemoveLiveWatchTestOk()
        {
            var request = new RemoveLiveWatchDocRequest()
            {
                DocId = "3F558898BEDE55D2F6F2C454AA6D2774",
                UserId = "Liza091995@hotmail.com"
            };
            var ret = _dal.RemoveLiveWatchDoc(request);

            Assert.AreEqual(1, ret.Tables.Count);
        }

        
    }
}