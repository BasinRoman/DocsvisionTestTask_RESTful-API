using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.DAL.Configuration
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.First_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Last_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Sure_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();

            //Профиль для дефолтного юзера
            builder.HasData(new Profile {Id = 1, User_id = 1});
        }
    }
}
