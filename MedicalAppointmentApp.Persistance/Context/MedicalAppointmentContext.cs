using MedicalAppointmentApp.Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentApp.Persistance.Context
{
    public class MedicalAppointmentContext : DbContext
    {
        public MedicalAppointmentContext(DbContextOptions<MedicalAppointmentContext> options)
            : base(options)
        {
        }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }
        
    }



    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // restricciones
        modelBuilder.Entity<MedicalRecords>()
            .HasOne<Specialties>()
            .WithMany()
            .HasForeignKey(m => m.SpecialtyID)
            .OnDelete(DeleteBehavior.Restrict);

        // mejora d eredimiento con ndices y restricciones
        modelBuilder.Entity<MedicalRecords>()
            .HasIndex(m => m.PatientID)
            .HasDatabaseName("Idx_PatientID");

        // requisitos de relaciones
        modelBuilder.Entity<AvailabilityModes>()
            .HasKey(da => da.AvailabilityModeID);
    }*/

}
