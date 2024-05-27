using System.Text.RegularExpressions;
using APBD_10.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Group = APBD_10.Entities.Group;

namespace APBD_10.Configs;

public class StudentEFConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.id).HasName("Student_pk");

        builder.Property(x => x.id).ValueGeneratedNever();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);

        //... dokonczyc tak jak groupsEFconfig
        
        builder.ToTable(nameof(Group));

        Group[] groups =
        {
            new Group { id = 1, name = "10c" },
            new Group { id = 2, name = "11c" },
            new Group { id = 3, name = "12c" }
        };

        builder.HasData(groups);
    }
}