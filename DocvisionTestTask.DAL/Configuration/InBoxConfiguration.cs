using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocvisionTestTask.DAL.Configuration
{
    internal class inBoxConfiguration : IEntityTypeConfiguration<inBox>
    {
        public void Configure(EntityTypeBuilder<inBox> builder)
        {
            builder.Property(x => x.id).ValueGeneratedOnAdd();    
            builder.Property(x => x.emailSubject).HasMaxLength(300).IsRequired();
            builder.Property(x => x.emailDate).IsRequired();
            builder.Property(x => x.emailFrom).HasMaxLength(50).IsRequired();
            builder.Property(x => x.emailTo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.emailBody).HasMaxLength(5000).IsRequired();
        }
    }
}
