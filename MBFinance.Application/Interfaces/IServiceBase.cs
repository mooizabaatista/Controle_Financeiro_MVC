using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBFinance.Application.Interfaces
{
    public interface IServiceBase<Entity> where Entity : class
    {
        public Task<IEnumerable<Entity>> GetAllAsync();
        public Task<Entity> GetByIdAsync(int id);
        public Task Create(Entity entity);
        public Task Update(Entity entity);
        public Task DeleteAsync(int id);
    }
}
