using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSistemaDeCelulares.Models.Configuration;

public class ConifgDiagnostic : IEntityTypeConfiguration<Diagnostic>
{
    public void Configure(EntityTypeBuilder<Diagnostic> builder)
    {
        builder.Property(d => d.Date).HasColumnType("datetime");
        builder.Property(d => d.EstimatedCost).HasColumnType("decimal(10,2)");
        builder.Property(d => d.Description).HasMaxLength(180);
        builder.Property(d => d.Date).HasColumnType("datetime");
        builder.HasKey(d => d.DiagnosisId);
    }
    
}