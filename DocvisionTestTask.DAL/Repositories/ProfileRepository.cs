using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.DAL.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Create(Profile entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> Select()
        {
            return _dbContext.Profile.Include(x => x.User).ToList();
        }
    }
}
