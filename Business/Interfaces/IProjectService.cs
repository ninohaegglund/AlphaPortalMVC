using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<int> CreateProjectAsync(AddProjectForm form);
        Task<ProjectDto?> GetProjectAsync(int id);
        Task<IEnumerable<ProjectDto?>> GetProjectsAsync();
        Task<bool> UpdateProjectAsync(int id, ProjectUpdateDto dto);
        Task<bool> DeleteProjectAsync(ProjectDto dto);
    }
}