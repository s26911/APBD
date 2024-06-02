using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class PrescriptionEFConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.IdPrescription).HasName("Prescription_pk");
        builder.Property(e => e.IdPrescription).UseIdentityColumn();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.DueDate).IsRequired();
        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Prescriptions)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Patient)
            .WithMany(e => e.Prescriptions)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Prescription");
    }
}