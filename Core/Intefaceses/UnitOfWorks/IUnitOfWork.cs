using System.Threading.Tasks;

namespace Core.Intefaceses.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
