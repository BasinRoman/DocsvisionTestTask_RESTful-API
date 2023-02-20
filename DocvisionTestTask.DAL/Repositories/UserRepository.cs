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
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByFNameLName(string FnameLname)
        {
            if (FnameLname.Split(" ").Count() > 1)
            {
                string Fname = FnameLname.Split(" ")[1];
                string LName = FnameLname.Split(" ")[0];
                var userToFind =  await _dbContext.Users.FirstOrDefaultAsync(x => x.Profile.First_name.Contains(Fname) && x.Profile.Last_name.Contains(LName));
                if (userToFind == null)
                {
                    userToFind = await _dbContext.Users.FirstOrDefaultAsync(x => x.Profile.First_name.Contains(LName) && x.Profile.Last_name.Contains(Fname));
                    if (userToFind == null)
                    {
                        throw new Exception($" [Адресат с фамилией {LName} и именем {Fname} не найден] ");
                    }
                }
                return userToFind;
            }
            else
            {
                throw new Exception(" [Невозможно определить адресата только по имени, или только по фамилии] ");
            }
            
        }

        public IEnumerable<User> Select()
        {
            return _dbContext.Users.Include(x => x.Profile).ToList();
        }
    }
}
