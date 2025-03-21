using Business.Dtos;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace WebApp.Controllers;

public class ProjectsController : Controller
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;

    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetProjectsAsync();
        return View("~/Views/Admin/projects.cshtml", projects);
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
