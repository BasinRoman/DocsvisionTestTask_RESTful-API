using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.DAL.Repositories
{
    internal class InBoxRepository : IInBoxRepository
    {
        public readonly ApplicationDbContext dbContext;
        public InBoxRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> Create(InBox entity)
        {
            throw new NotImplementedException();
        }

        public Task<InBox> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InBox>> Select()
        {
            throw new NotImplementedException();
        }
    }
}
