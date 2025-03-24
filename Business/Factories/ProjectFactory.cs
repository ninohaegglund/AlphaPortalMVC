
using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectDto Create(ProjectEntity entity)
    {
        return new ProjectDto
        {
            Name = entity.Name,
            ClientName = entity.ClientName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            Status = entity.Status
            
        };
    }

    public static ProjectEntity? Create(ProjectDto dto) => dto == null ? null : new ProjectEntity
    {
        Name = dto.Name,
        ClientName = dto.ClientName,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Budget = dto.Budget,
        Status = dto.Status
       
        
   
    };


    public static ProjectEntity Create(ProjectUpdateDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        ClientName = dto.ClientName,    
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Budget = dto.Budget,
        Status = dto.Status
        
    };

    public static ProjectUpdateDto? Create(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var entity = new ProjectUpdateDto
            {
                Id = project.Id,
                Name = project.Name,
                ClientName= project.ClientName,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Budget = project.Budget,
                Status = project.Status
                

            };

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
        ;
    }
}
