using APBD_10.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Entities;

public class HospitalDbContext : DbContext
{
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Medicament?> Medicaments { get; set; }
    public virtual DbSet<Patient?> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorEFConfig).Assembly);
    }
}