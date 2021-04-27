using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bll.Services;
using Bll.Services.Contracts;
using Dal.Models;
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
    public class MobilePhoneController : BaseController<MobilePhones>
    {
        public MobilePhoneController(IBaseService<MobilePhones> baseService) : base(baseService)
        {
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file.FileName == "Mobile.xlsx")
            {
                Upload<MobilePhones>(file);
            }
            if (file.FileName == "Plumbing.xlsx")
            {
                Upload<Plumbing>(file);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPage([FromQuery] PageRequestDto pageRequestDto)
        {
            Page(pageRequestDto);
        }
    }
}