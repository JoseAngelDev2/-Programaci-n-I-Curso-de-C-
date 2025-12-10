using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configuration;

public class ConfigPhoneDevice : IEntityTypeConfiguration<PhoneDevice>
{
    public void Configure(EntityTypeBuilder<PhoneDevice> builder)
    {
        builder.Property(p => p.Model).HasMaxLength(35);
        builder.Property(p => p.Brand).HasMaxLength(20);
        builder.Property(p => p.Status).HasMaxLength(15);
        builder.Property(p => p.Color).HasMaxLength(35);
        builder.Property(p => p.IMEI).HasMaxLength(15);
        builder.Property(p => p.CheckInDate).HasColumnType("datetime");
        
        builder.HasKey(p => p.PhoneDeviceId); 
    }
}