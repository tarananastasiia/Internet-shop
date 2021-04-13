using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteMy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IMobilePhoneService
    {
        void UploadFile(byte[] bin, IFormFile file);
        PageDTO<MobilePhones> GetFiltering(PageRequestDto pageRequestDto);
    }
}
