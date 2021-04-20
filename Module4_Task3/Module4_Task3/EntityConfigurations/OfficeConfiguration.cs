using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(100);

            builder.HasData(new List<Office>()
            {
                new Office() { OfficeId = 1, Title = "Israel HQ", Location = "Israel" },
                new Office() { OfficeId = 2, Title = "France HQ", Location = "France" },
                new Office() { OfficeId = 3, Title = "USA HQ", Location = "USA" },
                new Office() { OfficeId = 4, Title = "Ukraine HQ", Location = "Ukraine" }
            });
        }
    }
}
