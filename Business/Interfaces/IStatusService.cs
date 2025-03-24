using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<int> CreateStatusAsync(AddStatusForm form);
        Task<bool> DeleteStatusAsync(Status status);
        Task<StatusDto?> GetStatusAsync(int id);
        Task<IEnumerable<StatusDto?>> GetStatusesAsync();
        Task<bool> UpdateStatusAsync(StatusUpdateDto dto);
    }
}