using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteMy.Models;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/firstpage")]
    [EnableCors("AllowAllOrigin")]
    public class FirstPageController : Controller
    {
        ApplicationContext _context;
        public FirstPageController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}