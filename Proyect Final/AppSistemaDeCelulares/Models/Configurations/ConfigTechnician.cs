using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppSistemaDeCelulares.Models;

namespace AppSistemaDeCelulares.Models.Configurations;

public class ConfigTechnician : IEntityTypeConfiguration<Technician>
{
 
    public void Configure(EntityTypeBuilder<Technician> builder)
    { 
        builder.Property(t => t.Name).HasMaxLength(45);
        builder.Property(t => t.Specialty).HasMaxLength(85);
        builder.Property(t => t.Phone).HasMaxLength(20);
     
        builder.HasKey(t => t.TechnicianId);
    }
}