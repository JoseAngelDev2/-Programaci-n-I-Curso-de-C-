using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configurations;

public class ConfigDelivery : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.Property(d => d.TotalAmount)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(d => d.DeliveryDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(d => d.Notes).HasMaxLength(250); 
    }
}