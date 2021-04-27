using Dal.Models;
using DTOs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, object>> GetSorter(string columnName);
        PageDTO<TEntity> BaseGetFiltering(PageRequestDto pageRequestDto);
        void UploadFile<T>(byte[] bin, IFormFile file) where T : new();

    }
}
