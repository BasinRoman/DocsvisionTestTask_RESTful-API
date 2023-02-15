using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.DAL.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Login).HasMaxLength(25);
            builder.Property(x => x.Password).HasMaxLength(100);
            
            builder.HasOne(x => x.Profile).WithOne(x => x.User)
                                          .HasPrincipalKey<User>(x => x.Id)
                                          .OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(x => x.InBox).WithOne(x => x.User)
                                        .HasPrincipalKey<User>(x => x.Id)
                                        .OnDelete(DeleteBehavior.Cascade).IsRequired();

            //Создадим дефолтного юзера
            builder.HasData(new User
            {
                Id = 1,
                Login = "Roman",
                Password = HashPassword.Hash("123"),
            });
        }
    }
}
