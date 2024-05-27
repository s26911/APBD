using APBD_10.Configs;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Entities;

public class UniverityDbContext : DbContext
{
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Group> Groups { get; set; }

    public UniverityDbContext()
    {
        
    }

    public UniverityDbContext(DbContextOptions<DbContext> modelBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupEFConfig).Assembly);
    }
}