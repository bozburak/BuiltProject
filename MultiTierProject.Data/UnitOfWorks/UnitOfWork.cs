using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using System.Threading.Tasks;

namespace MultiTierProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MultiTierDbContext _multiTierDbContext;

        public UnitOfWork(MultiTierDbContext multiTierDbContext)
        {
            _multiTierDbContext = multiTierDbContext;
        }

        public void Commit()
        {
            _multiTierDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _multiTierDbContext.SaveChangesAsync();
        }
    }
}
