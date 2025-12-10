using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configurations;

public class ConfigRepairDetail: IEntityTypeConfiguration<RepairDetail>
{
    public void Configure(EntityTypeBuilder<RepairDetail> builder)
    {
        builder.HasKey(p => p.RepairDetailId);
        builder.Property(p => p.Description).HasMaxLength(80);
        builder.Property(p => p.Cost).HasColumnType("decimal(10,2)");
      
       
    
    }     
}