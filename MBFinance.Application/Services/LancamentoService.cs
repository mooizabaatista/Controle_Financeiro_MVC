using MBFinance.Application.Interfaces;
using MBFinance.Domain.Entities;
using MBFinance.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MBFinance.Application.Services
{
    public class LancamentoService : ServiceBase<Lancamento>, ILancamentoService
    {
        ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository repository) : base(repository)
        {
            _lancamentoRepository = repository;
        }
    }
}
