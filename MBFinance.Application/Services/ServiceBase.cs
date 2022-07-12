using MBFinance.Application.Interfaces;
using MBFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBFinance.Application.Services
{
    public class ServiceBase<Entity> : IServiceBase<Entity> where Entity : class
    {
        //Repository Injection
        private readonly IRepositoryBase<Entity> _repository;

        public ServiceBase(IRepositoryBase<Entity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task Create(Entity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task Update(Entity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
