using Core.Intefaces.UnitOfWorks;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext _projectDbContext;

        public UnitOfWork(ProjectDbContext ProjectDbContext)
        {
            _projectDbContext = ProjectDbContext;
        }

        public void Commit()
        {
            _projectDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _projectDbContext.SaveChangesAsync();
        }
    }
}
