using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bll.Services;
using Bll.Services.Contracts;
using DTOs.ViewModels;
using ExelImportUtil;
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
        IBaseService<MobilePhones> _baseService;

        public MobilePhoneController(IBaseService<MobilePhones> baseService)
        {
            _baseService = baseService;
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
                    if (file.FileName == "Mobile.xlsx")
                    {
                        _baseService.UploadFile(bin, file);
                    }
                    if(file.FileName == "Plumbing.xlsx")
                    {
                        _baseService.UploadFile(bin, file);
                    }
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPage([FromQuery]PageRequestDto pageRequestDto)
        {
            var result = _baseService.GetFiltering(pageRequestDto);
            return Ok(result);
        }
    }
}