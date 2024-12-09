using MedicalAppointmentApp.Persistance.Context; 
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentApp.Test.Context
{
    public class MedicalAppointmentMockContext : MedicalAppointmentContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("medicalappointmentdb"); 
        }
    }
}
