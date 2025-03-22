using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("admin")]
public class AdminController : Controller
{
    private readonly IProjectService _projectService;
    public AdminController(IProjectService projectService)
    {
        _projectService = projectService;   
    }


    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetProjectsAsync();
        return View("projects", projects); 
    }


    [Route("clients")]
    public IActionResult Clients()
    {
        return View();
    }

}
