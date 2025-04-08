using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebApp.Controllers;

public class ProjectsController : Controller
{
    
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;

    }
    


    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }
    

    [HttpGet]
    public async Task<IActionResult> Index(bool? status)
    {
        var projects = await _projectService.GetProjectsAsync();

        if (status.HasValue)
        {
            projects = projects.Where(p => p.Status == status.Value).ToList();
        }
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

    [HttpPost("admin/projects/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProjectUpdateDto dto)
    {

        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                );

            return Json(new { success = false, errors });

        }

        var result = await _projectService.UpdateProjectAsync(id, dto);

        if (result)
            return Json(new { success = true });

        return Json(new { success = false });


    }

    [HttpDelete("admin/projects/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);

        if (project == null)
            return NotFound();

        var deleted = await _projectService.DeleteProjectAsync(project);
        return deleted ? Ok() : BadRequest();
    }



}
