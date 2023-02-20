using DocvisionTestTask.DAL.Configuration;
using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocvisionTestTask.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<inBox> inBox { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Вынесем конфигурацию таблиц в отдельный класс
        {
            modelBuilder.ApplyConfiguration(new inBoxConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        }
    }
}