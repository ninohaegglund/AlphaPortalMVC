using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers;

public class ProjectsController : Controller
{
    private readonly ProjectService _projectService;
    private readonly ClientService _clientService;

    public ProjectsController(ProjectService projectService, ClientService clientService)
    {
        _projectService = projectService;
        _clientService = clientService;

    }


    [HttpPost]
    public async Task<IActionResult> Add(AddProjectForm form)
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return BadRequest(new { errors });
        }

        var result = await _projectService.CreateProjectAsync(form);
        if (result == 200)
            return Ok();

        return StatusCode(result);
    }
}
