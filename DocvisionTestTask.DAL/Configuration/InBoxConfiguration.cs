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
    internal class InBoxConfiguration : IEntityTypeConfiguration<InBox>
    {
        public void Configure(EntityTypeBuilder<InBox> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email_subject).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email_date).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email_from).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email_to).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email_body).HasMaxLength(50).IsRequired();

            //InBox для дефолтного юзера
            builder.HasData(new InBox {Id = 1, User_id = 1});
        }
    }
}
