using DocvisionTestTask.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocvisionTestTask.DAL.Configuration
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.firstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.lastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.sureName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();

            //Предопределенные профили
            builder.HasData(new Profile { Id = 1, userId = 1, firstName = "Общая почта",
                lastName = " ", Email = "dg_all@docvision.ru"});
            builder.HasData(new Profile { Id = 2, userId = 2, firstName = "Дмитрий",
                lastName = "Аносов", sureName = "Алексеевич", Email = "AnosovDA@docvision.ru" });
            builder.HasData(new Profile { Id = 3, userId = 3, firstName = "Игорь",
                lastName = "Вакин", sureName = "Дмитриевич", Email = "VakinID@docvision.ru" });
            builder.HasData(new Profile { Id = 4, userId = 4, firstName = "Ольга",
                lastName = "Микушина", sureName = "Андреевна", Email = "MikushinaOA@docvision.ru" });
            builder.HasData(new Profile { Id = 5, userId = 5, firstName = "Роман",
                lastName = "Басин", sureName = "Арсенович", Email = "BasinRA@docvision.ru" });
            builder.HasData(new Profile { Id = 6, userId = 6, firstName = "Олег",
                lastName = "Старов", sureName = "Сергеевич", Email = "StarovOS@docvision.ru" });
        }
    }
}
