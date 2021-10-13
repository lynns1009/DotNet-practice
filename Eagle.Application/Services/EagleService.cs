using Eagle.Application.Interfaces;
using Eagle.Domain.Models;
using Eagle.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eagle.Application.Services
{
    public class EagleService : IEagleService
	{
		private readonly IRedisRepository<TrafficPayload> _repository;

        public EagleService(IRedisRepository<TrafficPayload> redisRepository)
        {
            _repository = redisRepository ?? throw new ArgumentNullException(nameof(redisRepository));
        }
        public async Task<IEnumerable<TrafficPayload>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Save(TrafficPayload trafficPayload)
        {
            await _repository.Save(trafficPayload);
        }
    }
}
