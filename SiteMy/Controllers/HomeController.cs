using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteMy.Models;

namespace SiteMy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect($"~/api/firstPage/uploadFile");
        }
    }
}
