using Eagle.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eagle.Domain.Repositories
{
    public interface IRedisRepository
    {
        public Task<List<string>> GetAll();

        public Task<bool> Save(string dataId, string dataValue);
    }
}
