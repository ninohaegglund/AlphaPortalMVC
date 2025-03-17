using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task<int> CreateProjectAsync(AddProjectForm form)
    {
        try
        {
            if (await _projectRepository.ExistsAsync(x => x.Name == form.Name))
                return 409;

            var newProject = new ProjectEntity
            {
                Name = form.Name,
                ClientName = form.ClientName,
                Description = form.Description,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Budget = form.Budget,

            };

            await _projectRepository.AddAsync(newProject);

            return 200;
        }
        catch
        {
            return 500;
        }
    }
}