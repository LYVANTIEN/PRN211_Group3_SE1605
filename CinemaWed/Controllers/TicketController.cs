﻿using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
