using MBFinance.Domain.Entities;
using MBFinance.Domain.Interfaces;
using MBFinance.Infra.Context;

namespace MBFinance.Infra.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
