using MBFinance.Domain.Entities;
using MBFinance.Domain.Interfaces;
using MBFinance.Infra.Context;

namespace MBFinance.Infra.Repositories
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
