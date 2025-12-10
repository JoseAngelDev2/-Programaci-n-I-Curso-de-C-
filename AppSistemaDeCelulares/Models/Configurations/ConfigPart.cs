


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configurations;

public class ConfigPart : IEntityTypeConfiguration<Part>
{

    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.HasKey(p => p.PartId);
        builder.Property(p => p.Name).HasMaxLength(15);
        builder.Property(p => p.Price).HasColumnType("decimal(10, 2)");


    }
}