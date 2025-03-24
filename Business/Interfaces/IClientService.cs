using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IClientService
    {
        Task<int> CreateClientAsync(AddClientForm form);
        Task<bool> DeleteClientAsync(Status status);
        Task<ClientDto?> GetClientAsync(int id);
        Task<IEnumerable<ClientDto?>> GetClientsAsync();
        Task<bool> UpdateClientAsync(ClientUpdateDto dto);
    }
}