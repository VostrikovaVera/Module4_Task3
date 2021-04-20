using System;
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
            /*builder.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.HiredDate).IsRequired().HasColumnType("date");
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnType("date");
            builder.Property(p => p.HiredDate).IsRequired().HasColumnType("date");
            builder.Property(p => p.HiredDate).IsRequired().HasColumnType("date");*/

            /*builder.HasData(new List<Title>()
            {
                new Title() { EmployeeId = 1, FirstName = "Ross", LastName = "Geller", DateOfBirth = new DateTime(1975, 04, 04), HiredDate = new DateTime(2020, 04, 03), OfficeId = 2, TitleId = 3 },
                new Title() { EmployeeId = 2, FirstName = "Rachel", LastName = "Green", DateOfBirth = new DateTime(1985, 01, 31), HiredDate = new DateTime(2018, 01, 12), OfficeId = 1, TitleId = 1 }
            });*/
        }
    }
}
