namespace MedicalAppointmentApp.Persistance.Exceptions
{
    public class SpecialtiesDataException : Exception
    {
        public SpecialtiesDataException(string message) : base(message)
        {
        }

        public SpecialtiesDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
