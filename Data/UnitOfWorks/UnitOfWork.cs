using Core.Intefaceses.UnitOfWorks;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public class TokenHelp : IUnitOfWork
    {
        private readonly ProjectDbContext _ProjectDbContext;

        public TokenHelp(ProjectDbContext ProjectDbContext)
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
