using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(p => p.EmployeeProjectId);
            builder.Property(p => p.Rate).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnType("date");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<EmployeeProject>()
            {
                new EmployeeProject() { EmployeeProjectId = 1, Rate = 20, StartedDate = new DateTime(2019, 05, 19), EmployeeId = 1, ProjectId = 2 },
                new EmployeeProject() { EmployeeProjectId = 2, Rate = 30, StartedDate = new DateTime(2018, 07, 12), EmployeeId = 2, ProjectId = 3 },
                new EmployeeProject() { EmployeeProjectId = 3, Rate = 25, StartedDate = new DateTime(2020, 11, 08), EmployeeId = 2, ProjectId = 1 },
                new EmployeeProject() { EmployeeProjectId = 4, Rate = 25, StartedDate = new DateTime(2017, 09, 16), EmployeeId = 1, ProjectId = 4 }
            });
        }
    }
}
