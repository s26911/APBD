using APBD_10.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Configs;

public class StudenGroupEFConfig : IEntityTypeConfiguration<StudentGroup>
{
    public void Configure(EntityTypeBuilder<StudentGroup> builder)
    {
        builder.HasKey(x => new { x.idGroup, x.idStudent }).HasName("StudentGroup_pk");
        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        builder.HasOne(x => x.Student)
            .WithMany(x => x.StudentGroups)
            .HasForeignKey(x => x.idGroup)
            .HasConstraintName("StudentGroup_Group")
            .OnDelete(DeleteBehavior.Restrict);
    }
}