using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class PrescriptionMedicamentEFConfig : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        //TODO pk -> 2 fk
        // builder.Property(e => e.Dose)
        builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        builder.HasOne(e => e.Medicament)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Medicament")
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Prescription)
            .WithMany(e => e.PrescriptionMedicaments)
            .HasConstraintName("PrescriptionMedicament_Prescription")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("PrescriptionMedicament");

    }
}