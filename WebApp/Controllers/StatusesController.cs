using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class StatusesController : Controller
{
    private readonly IStatusService _statusService;

    public StatusesController(IStatusService statusService)
    {
        _statusService = statusService; 
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var statuses = await _statusService.GetStatusesAsync();

        return View("~/Views/Admin/statuses.cshtml", statuses);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddStatusForm form)
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

        var result = await _statusService.CreateStatusAsync(form);
        if (result == 200)
            return Ok();
        return StatusCode(result);
    }
}
