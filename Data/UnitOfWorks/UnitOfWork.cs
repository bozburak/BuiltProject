using Core.Intefaceses.UnitOfWorks;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public UnitOfWork(ProjectDbContext ProjectDbContext)
        {
            _ProjectDbContext = ProjectDbContext;
        }

        public void Commit()
        {
            _ProjectDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _ProjectDbContext.SaveChangesAsync();
        }
    }
}
