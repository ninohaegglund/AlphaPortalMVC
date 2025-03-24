

using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusFactory
{
    public static StatusDto? Create(StatusEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        return new StatusDto()
        {
            StatusName = entity.StatusName,
        };

    }
    public static StatusEntity Create(StatusDto dto) => new()
    {
        StatusName = dto.StatusName
        
    };


    public static StatusUpdateDto Create(Status status) => new()
    {
        Id = status.Id,
        StatusName = status.StatusName
        
    };

    public static StatusEntity Create(StatusUpdateDto dto) => new()
    {
        Id = dto.Id,
        StatusName = dto.StatusName
       
    };


}
