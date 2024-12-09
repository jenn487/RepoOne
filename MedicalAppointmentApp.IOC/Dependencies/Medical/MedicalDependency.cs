using MedicalAppointmentApp.Persistance.Interfaces.Configuration;
using MedicalAppointmentApp.Infraestructure.Interfaces;
using MedicalAppointmentApp.Aplication.Services.Medical;
using Microsoft.Extensions.DependencyInjection;
using MedicalAppointmentApp.Persistance.Repositories.Configuration;

namespace MedicalAppointmentApp.IOC.Dependencies.Medical
{
    public static class MedicalDependency 
    {
        public static void AddMedicalDependency(this IServiceCollection service)
        {
            service.AddScoped<IAvailabilityModesRepository, AvailabilityModesRepository>();
            service.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
            service.AddScoped<IMedicalRecordRepository, MedicalRecordsRepository>();

           
        }
    }

   

    
}
