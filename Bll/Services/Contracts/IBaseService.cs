using Dal.Models;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IBaseService<TEntity> where TEntity:class
    {
        void UploadFile(byte[] bin,IFormFile file);
        PageDTO<TEntity> GetFiltering(PageRequestDto pageRequestDto);
    }
}
