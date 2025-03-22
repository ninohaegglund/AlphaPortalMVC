using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ProjectService : IProjectService
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
                Budget = form.Budget

            };

            await _projectRepository.AddAsync(newProject);

            return 200;
        }
        catch
        {
            return 500;
        }
    }
    public async Task<IEnumerable<ProjectDto?>> GetProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();

        var projectDtos = entities.Select(ProjectFactory.Create)
                                   .Where(dto => dto != null)
                                   .ToList();

        return projectDtos;
    }
    public async Task<ProjectDto?> GetProjectAsync(int id)
    {
        var entities = await _projectRepository.GetAsync(x => x.Id == id);
        if (entities == null)
            return null!;
        var projects = ProjectFactory.Create(entities);
        return projects;
    }



}