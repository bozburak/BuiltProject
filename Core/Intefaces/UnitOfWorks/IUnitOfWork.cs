using System.Threading.Tasks;

namespace Core.Intefaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
