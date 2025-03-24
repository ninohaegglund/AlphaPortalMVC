using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;


namespace Business.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }


    public async Task<int> CreateClientAsync(AddClientForm form)
    {
        try
        {
            if (await _clientRepository.ExistsAsync(x => x.Email == form.Email))
                return 409;

            var newClient = new ClientEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Phone = form.Phone,
                JobTitle = form.JobTitle,
                DateOfBirth = form.DateOfBirth
            };

            await _clientRepository.AddAsync(newClient);

            return 200;
        }
        catch
        {
            return 500;
        }
    }

    public async Task<IEnumerable<ClientDto?>> GetClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync();

        var statusDtos = entities.Select(ClientFactory.Create)
                                   .Where(dto => dto != null)
                                   .ToList();
        return statusDtos;
    }

    public async Task<ClientDto?> GetClientAsync(int id)
    {
        var entity = await _clientRepository.GetAsync(x => x.Id == id);
        if (entity == null)
            return null!;

        var clientDto = ClientFactory.Create(entity);
        return clientDto;
    }

    public async Task<bool> UpdateClientAsync(ClientUpdateDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = ClientFactory.Create(dto);
            if (entity == null)
                return false;

            var result = await _clientRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<bool> DeleteClientAsync(Status status)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(status);

            var entity = await _clientRepository.GetAsync(x => x.Id == status.Id);

            if (entity == null)
                return false;

            var result = await _clientRepository.DeleteAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

}