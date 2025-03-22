

using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services
{
    public class StatusService(IStatusRepository statusRepository) : IStatusService
    {
        private readonly IStatusRepository _statusRepository = statusRepository;

        public async Task<IEnumerable<Status?>> GetAllStatusAsync()
        {
            var entities = await _statusRepository.GetAllAsync();
            return entities.Select(StatusFactory.Create);
        }

    }
}
