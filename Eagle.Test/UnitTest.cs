using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eagle.Domain.Models;
using System.Text.Json;
using Eagle.Domain;
using Eagle.Application.Services;
using Moq;
using Eagle.Domain.Repositories;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        private TrafficPayload trafficPayload;
        private EagleService eagleService;
        private Mock<IRedisRepository> mockRepo;

        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<IRedisRepository>();
            eagleService = new EagleService(mockRepo.Object);
            trafficPayload = new TrafficPayload
            {
                EagleBotGuid = System.Guid.NewGuid(),
                Latitude = -27.470125,
                Longitude = 153.021072,
                Date = new System.DateTime(),
                Direction = "east",
                Rate = 3.26,
                AverageSpeed = 60.26,
                RoadName = "Ann Street"
            };
        }
        [TestMethod]
        public void ShouldReturnTrueWhenSaveSuccessful()
        {
            var jsonString = JsonSerializer.Serialize(trafficPayload);
            mockRepo.Setup(r => r.Save(trafficPayload.EagleBotGuid.ToString(), jsonString)).ReturnsAsync(true);

            var savedResult = eagleService.Save(trafficPayload);

            Assert.AreEqual(savedResult.Result,true );
        }
    }
}
