using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.TitleId);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Title>()
            {
                new Title() { TitleId = 1, Name = "QA Engeneer" },
                new Title() { TitleId = 2, Name = "Front-End Developer" },
                new Title() { TitleId = 3, Name = ".Net Developer" },
                new Title() { TitleId = 4, Name = "DevOps Engeneer" },
                new Title() { TitleId = 5, Name = "UI/UX Designer" },
            });
        }
    }
}
