using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using System.Threading.Tasks;

namespace MultiTierProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MultiTierDbContext _multiTierDbContext1;

        public UnitOfWork(MultiTierDbContext multiTierDbContext)
        {
            _multiTierDbContext1 = multiTierDbContext;
        }

        public void Commit()
        {
            _multiTierDbContext1.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _multiTierDbContext1.SaveChangesAsync();
        }
    }
}
