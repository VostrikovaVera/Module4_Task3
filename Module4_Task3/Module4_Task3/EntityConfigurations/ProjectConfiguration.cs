using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).HasColumnType("date");

            builder.HasData(new List<Project>()
            {
                new Project() { ProjectId = 1, Name = "Zoom", Budget = 100000000, StartedDate = new DateTime(2020, 01, 25) },
                new Project() { ProjectId = 2, Name = "MonoBank", Budget = 2000000, StartedDate = new DateTime(2020, 05, 15) },
                new Project() { ProjectId = 3, Name = "Instagram", Budget = 17000000, StartedDate = new DateTime(2020, 03, 17) },
                new Project() { ProjectId = 4, Name = "Facebook", Budget = 4500000, StartedDate = new DateTime(2020, 08, 29) }
            });
        }
    }
}
