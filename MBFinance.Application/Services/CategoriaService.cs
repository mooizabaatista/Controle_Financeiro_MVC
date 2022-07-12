using MBFinance.Application.Interfaces;
using MBFinance.Domain.Entities;
using MBFinance.Domain.Interfaces;

namespace MBFinance.Application.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {

        }
    }
}
