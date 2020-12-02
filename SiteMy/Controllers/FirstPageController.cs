using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bll.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/firstPage")]
    [EnableCors("AllowAllOrigin")]
    public class FirstPageController : Controller
    {
        MobilePhoneService _mobilePhoneService;

        public FirstPageController(MobilePhoneService mobilePhoneService)
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

            return Ok("Ok suka");

        }
    }
}