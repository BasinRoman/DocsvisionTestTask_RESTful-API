using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocvisionTestTask.DAL.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            
            builder.Property(x => x.Login).HasMaxLength(25);
            builder.Property(x => x.Password).HasMaxLength(100);
            
            builder.HasOne(x => x.Profile).WithOne(x => x.User)
                                          .HasPrincipalKey<User>(x => x.id)
                                          .OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasMany(x => x.inBox).WithOne(x => x.User);

            //Предопределенные пользователи
            builder.HasData(new User { id = 1, Login = "Shared_account", Password = HashPassword.Hash("123")} );
            builder.HasData(new User { id = 2, Login = "Dmitry", Password = HashPassword.Hash("234") });
            builder.HasData(new User { id = 3, Login = "Igor", Password = HashPassword.Hash("345") });
            builder.HasData(new User { id = 4, Login = "Olga", Password = HashPassword.Hash("456") });
            builder.HasData(new User { id = 5, Login = "Roman", Password = HashPassword.Hash("567") });
            builder.HasData(new User { id = 6, Login = "Oleg", Password = HashPassword.Hash("678") });
        }
    }
}
