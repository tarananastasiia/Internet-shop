using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bll.Services;
using Bll.Services.Contracts;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteMy.Models;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/mobilePhone")]
    public class MobilePhoneController : Controller
    {
        IMobilePhoneService _mobilePhoneService;

        public MobilePhoneController(IMobilePhoneService mobilePhoneService)
        {
            _mobilePhoneService = mobilePhoneService;
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile()
        {
            var files = Request.Form.Files;

            if (files == null || files.Count == 0)
            {
                return BadRequest();
            }
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var bin = memoryStream.ToArray();
                    _mobilePhoneService.UploadFile(bin);
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Filtering([FromQuery]PageRequestDto pageRequestDto)
        {
            var result = _mobilePhoneService.GetFiltering(pageRequestDto);
            return Ok(result);
        }

        [HttpGet("sorting")]
        public IActionResult Sorter([FromQuery]SorterDto sortingDto)
        {
            var result = _mobilePhoneService.GetSorting(sortingDto);
            return Ok(result);
        }
    }
}