using Eagle.Domain.Models;
using Eagle.Domain.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;


namespace Eagle.Domain
{
    public class RedisRepository : IRedisRepository<TrafficPayload>
    {
        private readonly IConnectionMultiplexer _redis;
        public RedisRepository()
        {
            _redis = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { "localhost:6379" }
                }); ;
        }

        public Task<IEnumerable<TrafficPayload>> GetAll()
        {
            throw new  NotImplementedException();
        }

        public async Task Save(TrafficPayload data)
        {
            var redisDb = _redis.GetDatabase();
            var jsonString = JsonSerializer.Serialize(data);

            await redisDb.StringSetAsync(data.EagleBotId.ToString(), jsonString);
        }


    }
}
