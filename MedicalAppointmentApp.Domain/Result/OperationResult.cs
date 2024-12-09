﻿

namespace MedicalAppointmentApp.Domain.Result
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.Success = true;
        }

        public string? Message { get; set; }
        public dynamic? Data { get; set; }
        public bool Success { get; set; }
    }
}
