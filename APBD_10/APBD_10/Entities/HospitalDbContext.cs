using Microsoft.EntityFrameworkCore;

namespace APBD_10.Entities;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(..).Assembly);
    }}