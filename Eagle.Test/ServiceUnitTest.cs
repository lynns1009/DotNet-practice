using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eagle.Domain.Models;
using System.Text.Json;
using Eagle.Domain;
using Eagle.Application.Services;
using Moq;
using Eagle.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Eagle.Test
{
    [TestClass]
    public class ServiceUnitTest
    {
        private TrafficPayload trafficPayload1;
        private TrafficPayload trafficPayload2;
        private EagleService eagleService;
        private Mock<IRedisRepository> mockRepository;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IRedisRepository>();
            eagleService = new EagleService(mockRepository.Object);
            trafficPayload1 = new TrafficPayload
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

            trafficPayload2 = new TrafficPayload
            {
                EagleBotGuid = System.Guid.NewGuid(),
                Latitude = -40.470125,
                Longitude = 126.021072,
                Date = new System.DateTime(),
                Direction = "West",
                Rate = 56,
                AverageSpeed = 89.95,
                RoadName = "Jane Street"
            };
        }

        [TestMethod]
        public void ShouldReturnTrueWhenSaveSuccessful()
        {
            var jsonString = JsonSerializer.Serialize(trafficPayload1);
            mockRepository.Setup(r => r.Save(trafficPayload1.EagleBotGuid.ToString(), jsonString)).ReturnsAsync(true);

            var savedResult = eagleService.Save(trafficPayload1);

            Assert.AreEqual(savedResult.Result,true );
        }

        [TestMethod]
        public void ShouldReturnTrafficPayloadDataAsAList()
        {
            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(new List<string>{ JsonSerializer.Serialize(trafficPayload1), JsonSerializer.Serialize(trafficPayload2)});

            var getAllData = eagleService.GetAll();

            Assert.AreEqual(getAllData.Result.Count,2 );
            Assert.AreEqual(getAllData.Result.GetType(), typeof(List<TrafficPayload>));
            Assert.AreEqual(getAllData.Result[0].RoadName, "Ann Street");
            Assert.AreEqual(getAllData.Result[1].RoadName, "Jane Street");
        }
    }
}
