using MBFinance.Domain.Interfaces;
using MBFinance.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBFinance.Infra.Repositories
{
    public class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        //Context Injection
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        //Methods
        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        //GetById
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        //Create
        public async Task CreateAsync(Entity entity)
        {
            _context.Add(entity);
        }

        //Update
        public async Task UpdateAsync(Entity entity)
        {
            _context.Update(entity);
        }

        //Delete
        public async Task DeleteAsync(int id)
        {
            var entity = _context.Set<Entity>().FindAsync(id).Result;
            _context.Remove(entity);
        }
    }
}
