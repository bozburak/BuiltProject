using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
