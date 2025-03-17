﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Clients", "Admin");
    }
}
