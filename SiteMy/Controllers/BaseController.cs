using Bll.Services.Contracts;
using Dal.Models;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMy.Controllers
{
    public class BaseController<TEntity> : Controller where TEntity : class
    {
        public int a;
        IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        public async Task<IActionResult> Upload<T>(IFormFile file) where T : new()
        {
            if (file == null)
            {
                return BadRequest();
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var bin = memoryStream.ToArray();
                _baseService.UploadFile<T>(bin, file);
            }
            return Ok();
        }

        public IActionResult Page([FromQuery] PageRequestDto pageRequestDto)
        {
            var result = _baseService.BaseGetFiltering(pageRequestDto);
            return Ok(result);
        }
    }
}
