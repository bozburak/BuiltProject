using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
