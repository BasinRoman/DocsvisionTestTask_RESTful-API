using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DocvisionTestTask.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Profile> Select()
        {
            return _dbContext.Profile.Include(x => x.User).ToList();
        }
        public Task<bool> Create(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}
