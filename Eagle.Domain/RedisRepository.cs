using Eagle.Domain.Models;
using Eagle.Domain.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Eagle.Domain
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IConnectionMultiplexer _redis;
        public RedisRepository()
        {
            _redis = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { "localhost:6379" },
                    AbortOnConnectFail = false
                }); ;
        }

        public async Task<List<string>> GetAll()
        {
            var result = new List<string>();
            var keys = _redis.GetServer("localhost", 6379).Keys();
            var keysArr = keys.Select(key => (string)key);
            var redisDb = _redis.GetDatabase();

            foreach (string key in keysArr)
            {
                result.Add(await redisDb.StringGetAsync(key));
            }
            return result;
        }

        public async Task<bool> Save( string dataId, string dataJson)
        {
            var redisDb = _redis.GetDatabase();

            return await redisDb.StringSetAsync(dataId, dataJson);
        }


    }
}
