using Eagle.Domain;
using Eagle.Domain.Models;
using Eagle.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Eagle.Test
{
    [TestClass]
    public class RedisIntegrationTest
    {
        private TrafficPayload trafficPayload;
        private IRedisRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new RedisRepository();
            trafficPayload = new TrafficPayload
            {
                EagleBotGuid = System.Guid.NewGuid(),
                Latitude = -27.470125,
                Longitude = 153.021072,
                Date = new System.DateTime(),
                Direction = "East",
                Rate = 3.26,
                AverageSpeed = 60.26,
                RoadName = "Ann Street"
            };
        }

        //[TestCleanup]
        //public void Cleanup()
        //{
            // Normally, we need to clean up the data in Redis to make sure the integration test run multiple times. 
            // What I will do is to create a delete function in Repository, but since delete is out of scope and
            // I don't think it's a good idea to write function only for test purpose.
        //}

        [TestMethod]
        public void ShouldSaveTrafficPayloadIntoRedisDB()
        {
            var jsonString = JsonSerializer.Serialize(trafficPayload);

            var savedResult = repository.Save(trafficPayload.EagleBotGuid.ToString(),jsonString);
            var allData = repository.GetAll();

            Assert.AreEqual(savedResult.Result, true);
            Assert.AreEqual(allData.Result.Count, 1);
        }
    }
}
