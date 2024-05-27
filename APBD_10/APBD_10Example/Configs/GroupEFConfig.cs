using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Group = APBD_10.Entities.Group;

namespace APBD_10.Configs;

public class GroupEFConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.id).HasName("Group_pk");

        builder.Property(x => x.id).ValueGeneratedNever();

        builder.Property(x => x.name).IsRequired().HasMaxLength(5);

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