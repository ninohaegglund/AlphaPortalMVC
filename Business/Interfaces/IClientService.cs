using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IClientService
    {
        Task<int> CreateClientAsync(AddClientForm form);
        Task<IEnumerable<ClientEntity>> GetClientsAsync();
    }
}