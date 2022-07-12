using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBFinance.Domain.Interfaces
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
        public Task<IEnumerable<Entity>> GetAllAsync();
        public Task<Entity> GetByIdAsync(int id);
        public Task CreateAsync(Entity entity);
        public Task UpdateAsync(Entity entity);
        public Task DeleteAsync(int id);
    }
}
