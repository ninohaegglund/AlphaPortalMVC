using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("admin")]


public class AdminController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IStatusService _statusService;
    private readonly IClientService _clientService;
    public AdminController(IProjectService projectService, IStatusService statusService, IClientService clientService)
    {
        _projectService = projectService;
        _statusService = statusService;
        _clientService = clientService;
    }


    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return View("projects", projects); 
    }

    [HttpGet("projects/{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }


    [Route("clients")]
    public async Task <IActionResult>  Clients()
    {
        var clients = await _clientService.GetClientsAsync();
        return View("clients", clients);
    }

    [Route("statuses")]
    public async Task<IActionResult> Statuses()
    {
        var statuses = await _statusService.GetStatusesAsync();
        return View("statuses", statuses);
    }

}
