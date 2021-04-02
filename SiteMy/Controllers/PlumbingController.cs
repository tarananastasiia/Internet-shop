using Bll.Services.Contracts;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/plumbing")]
    public class PlumbingController: Controller
    {
        IPlumbingService _plumbingService;

        public PlumbingController( IPlumbingService plumbingService)
        {
            _plumbingService = plumbingService;
        }
        [HttpGet]
        public IActionResult GetPage([FromQuery] PageRequestDto pageRequestDto)
        {
            var result = _plumbingService.GetFiltering(pageRequestDto);
            return Ok(result);
        }
    }
}
