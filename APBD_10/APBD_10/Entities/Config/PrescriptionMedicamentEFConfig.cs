using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class PrescriptionMedicamentEFConfig : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(e => new { e.MedicamentId, e.PrescriptionId });
        builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        
        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Medicament")
            .HasForeignKey(e => e.MedicamentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Prescription")
            .HasForeignKey(e => e.PrescriptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("PrescriptionMedicament");

    }
}