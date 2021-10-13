using Eagle.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eagle.Domain.Repositories
{
    public interface IRedisRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task Save(TrafficPayload data);
    }
}
