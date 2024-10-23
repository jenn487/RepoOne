using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Domain.Entities.Appointments
{
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateOnly AvailableDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        //  configuracion sobre la disponibilidad en tiempo real
        public void UpdateAvailability(DateOnly date, TimeSpan start, TimeSpan end)
        {
            AvailableDate = date;
            StartTime = start;
            EndTime = end;
        }
    }
}
