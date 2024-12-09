namespace MedicalAppointmentApp.Infraestructure.Results
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data) =>
            new ServiceResult<T> { Success = true, Data = data };

        public static ServiceResult<T> ErrorResult(string message) =>
            new ServiceResult<T> { Success = false, Message = message };
    }

    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static ServiceResult SuccessResult() =>
            new ServiceResult { Success = true };

        public static ServiceResult ErrorResult(string message) =>
            new ServiceResult { Success = false, Message = message };
    }
}