using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.EmployeeId);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.HiredDate).IsRequired().HasColumnType("date");
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnType("date");

            /*builder.HasMany(c => c.Products)
                .WithMany(s => s.Companies)
                .UsingEntity<Dictionary<string, object>>(
                    "Supply",
                    j => j
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("ProductId"),
                    j => j
                        .HasOne<Company>()
                        .WithMany()
                        .HasForeignKey("CompanyId"));*/

            builder.HasOne(d => d.Title)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Employee>()
            {
                new Employee() { EmployeeId = 1, FirstName = "Ross", LastName = "Geller", DateOfBirth = new DateTime(1975, 04, 04), HiredDate = new DateTime(2020, 04, 03), OfficeId = 2, TitleId = 3 },
                new Employee() { EmployeeId = 2, FirstName = "Rachel", LastName = "Green", DateOfBirth = new DateTime(1985, 01, 31), HiredDate = new DateTime(2018, 01, 12), OfficeId = 1, TitleId = 1 }
            });
        }
    }
}
