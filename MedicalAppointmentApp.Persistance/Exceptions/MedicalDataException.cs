

namespace MedicalAppointmentApp.Persistance.Exceptions
{
    public class MedicalDataException : Exception
    {
        public MedicalDataException(string message) : base(message) { }
        public MedicalDataException(string message, Exception inner) : base(message, inner) { }
    }
}
