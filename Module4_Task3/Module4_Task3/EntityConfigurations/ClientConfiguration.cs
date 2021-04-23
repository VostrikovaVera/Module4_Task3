using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_Task3.Entities;

namespace Module4_Task3.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(p => p.ClientId);
            builder.Property(p => p.CompanyName).HasMaxLength(100);
            builder.Property(p => p.IsActive).HasColumnType("bit");
            builder.Property(p => p.FoundationDate).HasColumnType("date");
            builder.Property(p => p.ActvityScope).HasMaxLength(50);
        }
    }
}
