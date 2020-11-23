using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SiteMy.Models;
using SiteMy.Services;

namespace SiteMy.Controllers
{
    [ApiController]
    [Route("api/firstpage")]
    [EnableCors("AllowAllOrigin")]
    public class FirstPageController : Controller
    {
        EpplusFileReadService epplusFileReadService;
        public void Get()
        {
            List<string> mobilePhones = new List<string>();
            epplusFileReadService.GetMobilePhones(mobilePhones);

        }
    }
}