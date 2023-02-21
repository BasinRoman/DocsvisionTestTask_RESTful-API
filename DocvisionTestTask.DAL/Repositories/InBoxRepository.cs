using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;

namespace DocvisionTestTask.DAL.Repositories
{
    public class InBoxRepository : IInBoxRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public InBoxRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(inBox entity)
        {
            await _dbContext.inBox.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<inBox> Select()
        {
            throw new NotImplementedException();
        }
    }
}
