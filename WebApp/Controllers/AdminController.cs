using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("admin")]
public class AdminController : Controller
{
    private readonly ProjectService _projectService;
    public AdminController(ProjectService projectService)
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
