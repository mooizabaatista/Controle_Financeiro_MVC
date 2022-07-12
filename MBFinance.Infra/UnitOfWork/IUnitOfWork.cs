using System.Threading.Tasks;

namespace MBFinance.Infra.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task Commit();
        public Task RollBack();
    }
}
