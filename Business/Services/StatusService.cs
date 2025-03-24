using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Diagnostics;


namespace Business.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }


    public async Task<int> CreateStatusAsync(AddStatusForm form)
    {
        try
        {
            if (await _statusRepository.ExistsAsync(x => x.StatusName == form.StatusName))
                return 409;

            var newStatus = new StatusEntity
            {
                StatusName = form.StatusName,

            };

            await _statusRepository.AddAsync(newStatus);

            return 200;
        }
        catch
        {
            return 500;
        }
    }

    public async Task<IEnumerable<StatusDto?>> GetStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync();

        var statusDtos = entities.Select(StatusFactory.Create)
                                   .Where(dto => dto != null)
                                   .ToList();

        return statusDtos;
    }

    public async Task<StatusDto?> GetStatusAsync(int id)
    {
        var entity = await _statusRepository.GetAsync(x => x.Id == id);
        if (entity == null)
            return null!;

        var statusDto = StatusFactory.Create(entity);
        return statusDto;
    }

    public async Task<bool> UpdateStatusAsync(StatusUpdateDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = StatusFactory.Create(dto);
            if (entity == null)
                return false;

            var result = await _statusRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<bool> DeleteStatusAsync(Status status)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(status);

            var entity = await _statusRepository.GetAsync(x => x.Id == status.Id);

            if (entity == null)
                return false;

            var result = await _statusRepository.DeleteAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

}