
namespace MedicalAppointmentApp.Aplication.Base
{
    public interface IBaseService<TResponse, TSaveDto, TUpdateDto>
    {
        Task<TResponse> SaveAsync(TSaveDto dto);
        Task<TResponse> UpdateAsync(TSaveDto dto);
        Task<TResponse> UpdateAsync(TUpdateDto dto);
        Task<TResponse> GetById(int Id);
    }
}
