using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DocvisionTestTask.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByFNameLName(string FnameLname)
        {
            if (FnameLname == "") { throw new Exception("Адресат не указан"); }
            if (FnameLname.Split(" ").Count() > 1)
            {
                string Fname = FnameLname.Split(" ")[1];
                string LName = FnameLname.Split(" ")[0];
                var userToFind =  await _dbContext.Users.FirstOrDefaultAsync(x => x.Profile.firstName.Contains(Fname) && x.Profile.lastName.Contains(LName));
                if (userToFind == null)
                {
                    userToFind = await _dbContext.Users.FirstOrDefaultAsync(x => x.Profile.firstName.Contains(LName) && x.Profile.lastName.Contains(Fname));
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

        // Получение всех пользоавтелей с lazyloading связанных записей из таблицы Profile
        public IEnumerable<User> Select()
        {
            return _dbContext.Users.Include(x => x.Profile).ToList();
        }

        public Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
