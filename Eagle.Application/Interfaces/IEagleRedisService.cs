using Eagle.Domain;
using Eagle.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eagle.Application.Interfaces
{
    public interface IEagleRedisService
	{
		Task<List<TrafficPayload>> GetAll();
		Task<bool> Save(TrafficPayload trafficPayload);
	}
}
