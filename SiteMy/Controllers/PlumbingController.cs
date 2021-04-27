using Bll.Services.Contracts;
using Dal.Models;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/plumbing")]
    public class PlumbingController: Controller
    {
        IBaseService<Plumbing> _plumbingService;

        public PlumbingController(IBaseService<Plumbing> plumbingService)
        {
            _plumbingService = plumbingService;
        }
        [HttpGet]
        public IActionResult GetPage([FromQuery] PageRequestDto pageRequestDto)
        {
            var result = _plumbingService.BaseGetFiltering(pageRequestDto);
            return Ok(result);
        }
    }
}
