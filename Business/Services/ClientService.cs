using Business.Models;
using Data.Entities;
using Data.Interfaces;


namespace Business.Services;

public class ClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService (IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }


    public async Task<int> CreateClientAsync(AddClientForm form)
    {
        try
        {
            if (await _clientRepository.ExistsAsync(x => x.ClientName == form.ClientName))
                return 409;

            var newClient = new ClientEntity
            {
                ClientName = form.ClientName,
                Email = form.Email,
                Phone = form.Phone,
                Location = form.Location
                
            };

            await _clientRepository.AddAsync(newClient);

            return 200;
        }
        catch
        {
            return 500;
        }
    }

    public async Task<IEnumerable<ClientEntity>> GetClientsAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients;

    }
    
}