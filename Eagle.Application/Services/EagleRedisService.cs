using Eagle.Application.Interfaces;
using Eagle.Domain.Models;
using Eagle.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eagle.Application.Services
{
    public class EagleRedisService : IEagleRedisService
	{
		private readonly IRedisRepository _repository;

        public EagleRedisService(IRedisRepository redisRepository)
        {
            _repository = redisRepository ?? throw new ArgumentNullException(nameof(redisRepository));
        }
        public async Task<List<TrafficPayload>> GetAll()
        {
            var result = new List<TrafficPayload>();
            var dataList =  await _repository.GetAll();
            foreach (var item in dataList)
            {
                result.Add(JsonSerializer.Deserialize<TrafficPayload>(item));
            }
            return result;
        }

        public async Task<bool> Save(TrafficPayload trafficPayload)
        {
            var dataGuid = trafficPayload.EagleBotGuid.ToString();
            var dataValue = JsonSerializer.Serialize(trafficPayload);

            return await _repository.Save(dataGuid, dataValue);
        }
    }
}
