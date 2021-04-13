using Dal.Models;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IPlumbingService
    {
        void UploadFile(byte[] bin,IFormFile file);
        PageDTO<Plumbing> GetFiltering(PageRequestDto pageRequestDto);
    }
}
