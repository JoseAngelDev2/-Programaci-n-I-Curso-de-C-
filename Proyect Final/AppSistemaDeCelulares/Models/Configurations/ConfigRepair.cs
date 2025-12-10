using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configurations;

public class ConfigRepair : IEntityTypeConfiguration<Repair>
{

    public void Configure(EntityTypeBuilder<Repair> builder)
    {
        builder.HasKey(r => r.RepairId);
        builder.Property(r => r.Status).HasMaxLength(15);
        builder.Property(r => r.LaborCost).HasColumnType("decimal(10, 2)");
        builder.Property(r => r.StartDate).HasColumnType("datetime");

    }
}
