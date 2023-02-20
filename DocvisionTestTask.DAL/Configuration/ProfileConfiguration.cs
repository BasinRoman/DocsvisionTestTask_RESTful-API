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

            //Предопределенные профили
            builder.HasData(new Profile { Id = 1, UserId = 1, First_name = "Общая почта", Last_name = " ", Email = "dg_all@docvision.ru"});
            builder.HasData(new Profile { Id = 2, UserId = 2, First_name = "Дмитрий", Last_name = "Аносов", Sure_name = "Алексеевич", Email = "AnosovDA@docvision.ru" });
            builder.HasData(new Profile { Id = 3, UserId = 3, First_name = "Игорь", Last_name = "Вакин", Sure_name = "Дмитриевич", Email = "VakinID@docvision.ru" });
            builder.HasData(new Profile { Id = 4, UserId = 4, First_name = "Ольга", Last_name = "Микушина", Sure_name = "Андреевна", Email = "MikushinaOA@docvision.ru" });
            builder.HasData(new Profile { Id = 5, UserId = 5, First_name = "Роман", Last_name = "Басин", Sure_name = "Арсенович", Email = "BasinRA@docvision.ru" });
            builder.HasData(new Profile { Id = 6, UserId = 6, First_name = "Олег", Last_name = "Старов", Sure_name = "Сергеевич", Email = "StarovOS@docvision.ru" });
        }
    }
}
