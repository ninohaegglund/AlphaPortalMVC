using Business.Models;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<Status?>> GetAllStatusAsync();
    }
}