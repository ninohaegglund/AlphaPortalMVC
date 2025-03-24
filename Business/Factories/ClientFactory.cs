

using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ClientFactory
{
    public static ClientDto? Create(ClientEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        return new ClientDto()
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            JobTitle = entity.JobTitle,
            DateOfBirth = entity.DateOfBirth

        };

    }
    public static ClientEntity Create(ClientDto dto) => new()
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        Phone = dto.Phone,
        JobTitle = dto.JobTitle,
        DateOfBirth = dto.DateOfBirth

    };


    public static ClientUpdateDto Create(Client client) => new()
    {
        Id = client.Id,
        FirstName = client.FirstName,
        LastName = client.LastName,
        Email = client.Email,
        Phone = client.Phone,
        JobTitle = client.JobTitle,
        DateOfBirth = client.DateOfBirth

    };

    public static ClientEntity Create(ClientUpdateDto dto) => new()
    {
        Id = dto.Id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        Phone = dto.Phone,
        JobTitle = dto.JobTitle,
        DateOfBirth = dto.DateOfBirth

    };


}
